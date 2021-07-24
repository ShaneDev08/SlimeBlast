using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Launcher : MonoBehaviour
{
    // Rigidbodys
    private Rigidbody2D rb;
    public Rigidbody2D[] rbs;



    // Game Components 
    public CinemachineTargetGroup target1;
    public CinemachineVirtualCamera cam;
    public AudioClip launchSound;
    public ObjectPool pool;
    public Transform shootFrom;
    public GameObject explosion;
    public Transform floor;
    private GameObject jellyRef;
    private GameObject slimeSpawned;
    private AudioSource audio;
    private SpriteRenderer[] sprites;

    // Script Variables
    private float launchMultiplier;
    private bool hasSpawned;
    private bool hasFoundRb;
    private bool multipleRb;


    // TO DO 
    // Use upgrades class to add in upgrades to the launcher. Then we can check to see if upgrades have been unlocked and then use them
    private Upgrades[] upgrades = new Upgrades[5];      // Set the amount of upgrades we are going to put in

    private void Start()
    {

        cam.m_Lens.NearClipPlane = -5;
        // Register to event when fire button is no longer pressed
        EventManager.instance.LaunchSlime += LaunchSlime;

        // Cache AudioSource from sound manager
        audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();

        

    }

    private void Update()
    {
        // Check to see if slime has multiple Rbs and adds them to the array
        if (PlayerManager.instance.slimeBall.GetComponent<SlimeBall>().slimeStats.multipleRbs)
        {
           
            if (GameObject.Find(PlayerManager.instance.slimeBall.gameObject.name + "(Clone) Reference Points") != null)
            {
                AddRbs();
                if (!hasFoundRb)
                {
                    foreach (Rigidbody2D rbbs in rbs)
                    {
                        rbbs.gravityScale = 0;
                    }
                    hasFoundRb = true;
                }
            }
            if (!hasSpawned)
            {
                slimeSpawned = pool.GetObject();

                slimeSpawned.transform.position = shootFrom.transform.position;
                slimeSpawned.GetComponent<MeshRenderer>().enabled = false;
                sprites = slimeSpawned.GetComponentsInChildren<SpriteRenderer>();
                for (int i = 0; i < sprites.Length; i++)
                {
                    sprites[i].enabled = false;
                }
                hasSpawned = true;




            }
            multipleRb = true;
        }

        // Anything under here is for standard Slimes
    }



    #region OnEventLaunchSlime
    // This method will get called by an EVENT which is when the player lets go of the power button
    public void LaunchSlime()
    {
        // If standard slime with one RB then get the RB and send it over to the method for standard 1 RB
        if (!multipleRb)
        {
            slimeSpawned = pool.GetObject();
            slimeSpawned.transform.position = shootFrom.transform.position;


            PlayerManager.instance.slimeInGame = slimeSpawned;
            Rigidbody2D rb = slimeSpawned.GetComponent<Rigidbody2D>();

            audio.PlayOneShot(launchSound);

            // Check to see if powerUpgrade is enabled
            Debug.Log(PlayerManager.shopUpgrades["Cannon"].isEnabled);
            if (PlayerManager.shopUpgrades["Cannon"].isEnabled)
            {
                Debug.Log("Launch With extra Power");
                LaunchWithPowerUpgrade(rb);
            }
            else
            {
                Debug.Log("Launch With No Power");
                LaunchWithNoUpgrades(rb);
            }

           


            //cam.LookAt = slimeSpawned.transform;
            //cam.Follow = slimeSpawned.transform;
        }

        // Else Launch with multipleRbs
        else if (PlayerManager.instance.slimeBall.GetComponent<SlimeBall>().slimeStats.multipleRbs)
        {

            if (PlayerManager.shopUpgrades["Cannon"].isEnabled)
            {
                LaunchWithPowerUpgrade(rbs);
            }
            else
            {
                LaunchWithNoUpgrades(rbs);
            }
            audio.PlayOneShot(launchSound);
            
        }

    }
    #endregion


    #region LauncherWithOrWithoutUpgrades

    // These methods are for slimes that have standard RB or multiple Rbs 


    // Method takes an array of rigidbodys
    private void LaunchWithNoUpgrades(Rigidbody2D[] rb)
    {
        // Enables the Mesh so we can see it
        EnableMesh();

        // Loops through each Rb and adds gravity and force. Also creates an explosion and adds slime to target group
        foreach (Rigidbody2D rb2 in rbs)
        {

            rb2.gravityScale = 1;
            slimeSpawned.GetComponent<SlimeBall>().hasSpawned = true;
            rb2.AddForce(transform.right * UIManager.instance.powerAmount / 10 , ForceMode2D.Impulse);
            // Launch in the Air
            rb2.AddForce(Vector3.up * UIManager.instance.powerAmount / 10 , ForceMode2D.Impulse);
            
        }
        Instantiate(explosion, shootFrom.transform.position, explosion.transform.rotation);
        target1.AddMember(slimeSpawned.transform, 2, 5);
        target1.RemoveMember(gameObject.transform);
        target1.RemoveMember(floor);
    }


    // Standard Method for one Rb. Adds force and creates an explosion and also adds slime to target
    private void LaunchWithNoUpgrades(Rigidbody2D rb)
    {
            rb.AddForce(transform.right * UIManager.instance.powerAmount / 10 * 12, ForceMode2D.Impulse);
            // Launch in the Air
            rb.AddForce(Vector3.up * UIManager.instance.powerAmount / 10 * 12, ForceMode2D.Impulse);
            Instantiate(explosion, shootFrom.transform.position, explosion.transform.rotation);
        

        target1.AddMember(slimeSpawned.transform, 2, 5);
        target1.RemoveMember(gameObject.transform);
    }


    #region TODOLAUNCHSLIMEWITHUPGRADE
    private void LaunchWithPowerUpgrade(Rigidbody2D rb)
    {
        Debug.Log("POWERRRRRR");
        PowerUpgrade power = (PowerUpgrade)PlayerManager.shopUpgrades["Cannon"];
        rb.AddForce(transform.right * UIManager.instance.powerAmount / 10 * power.powerModifier, ForceMode2D.Impulse);
        // Launch in the Air
        
        rb.AddForce(Vector3.up * UIManager.instance.powerAmount / 10 * power.powerModifier , ForceMode2D.Impulse);

        target1.AddMember(slimeSpawned.transform, 1, 0);
    }

    private void LaunchWithPowerUpgrade(Rigidbody2D[] rb)
    {
        EnableMesh();
        Debug.Log("POWERRRRRR");
        PowerUpgrade power = (PowerUpgrade)PlayerManager.shopUpgrades["Cannon"];
        foreach (Rigidbody2D rbs in rb)
        {
            rbs.gravityScale = 1;
            slimeSpawned.GetComponent<SlimeBall>().hasSpawned = true;
            rbs.AddForce(transform.right * UIManager.instance.powerAmount / 10 * power.powerModifier, ForceMode2D.Impulse);
            // Launch in the Air

            rbs.AddForce(Vector3.up * UIManager.instance.powerAmount / 10 * power.powerModifier, ForceMode2D.Impulse);
         }

        target1.AddMember(slimeSpawned.transform, 2, 5);
        target1.RemoveMember(gameObject.transform);
        target1.RemoveMember(floor);
    }
    #endregion



    #endregion

    #region AddsRb
    private void AddRbs()
    {
        jellyRef = GameObject.Find(PlayerManager.instance.slimeBall.gameObject.name + "(Clone) Reference Points");
        rbs = jellyRef.GetComponentsInChildren<Rigidbody2D>();

    }

    #endregion

    #region TankUpgradesToDOLIST
    // Added the jump here. If the abillity is enabled then we can show a button??
    //public void Jump()
    //{
    //    if (PlayerManager.abillities[0].isEnabled)
    //    {
    //        Debug.Log("Jump");
    //        slimeSpawned.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50f, ForceMode2D.Impulse);
    //    }
    //}



    #endregion


    private void EnableMesh()
    {
        slimeSpawned.GetComponent<MeshRenderer>().enabled = true;
        for (int i = 0; i < sprites.Length; i++)
        {
            // Enables the Eyes 
            sprites[i].enabled = true;
        }

    }
}
