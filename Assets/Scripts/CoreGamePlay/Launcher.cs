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
    private CinemachineTargetGroup target1;
    private CinemachineVirtualCamera cam;
    public AudioClip launchSound;
    private ObjectPool pool;
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

    public CannonSo cannonStats;


    // TO DO 
    // Use upgrades class to add in upgrades to the launcher. Then we can check to see if upgrades have been unlocked and then use them
    private Upgrades[] upgrades = new Upgrades[5];      // Set the amount of upgrades we are going to put in

    private void Start()
    {

        pool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
        target1 = GameObject.Find("TargetGroup").GetComponent<CinemachineTargetGroup>();
        target1.AddMember(this.gameObject.transform, 1, 1);
        cam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        floor = GameObject.Find("GameStartFloor").transform;


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


                slimeSpawned.GetComponent<MeshRenderer>().enabled = false;
                sprites = slimeSpawned.transform.Find("Eyes").GetComponentsInChildren<SpriteRenderer>();
                for (int i = 0; i < sprites.Length; i++)
                {
                    sprites[i].enabled = false;
                }
                //jellyRef.transform.position = slimeSpawned.transform.position;


                hasSpawned = true;

            }
            multipleRb = true;
            //slimeSpawned.transform.position = shootFrom.transform.position;
            if (jellyRef != null)
            jellyRef.transform.position = shootFrom.transform.position;

        }

        // Anything under here is for standard Slimes
    }



    #region OnEventLaunchSlime
    // This method will get called by an EVENT which is when the player lets go of the power button
    public void LaunchSlime()
    {

        // Else Launch with multipleRbs
        if (PlayerManager.instance.slimeBall.GetComponent<SlimeBall>().slimeStats.multipleRbs)
        {

            if (cannonStats.powerUpgrade.currentUpgrade > 0)
            {
                LaunchWithPowerUpgrade();
            }

            LaunchWithNoUpgrades();
            
            audio.PlayOneShot(launchSound);
            
        }

    }
    #endregion


    #region LauncherWithOrWithoutUpgrades

    // These methods are for slimes that have standard RB or multiple Rbs 


    // Method takes an array of rigidbodys
    private void LaunchWithNoUpgrades()
    {
        // Enables the Mesh so we can see it
        EnableMesh();
        
        // Loops through each Rb and adds gravity and force. Also creates an explosion and adds slime to target group
        foreach (Rigidbody2D rb2 in rbs)
        {

            rb2.gravityScale = 1;
            slimeSpawned.GetComponent<SlimeBall>().hasSpawned = true;
            rb2.AddForce(transform.right * (UIManager.instance.powerAmount) / 10 , ForceMode2D.Impulse);
            // Launch in the Air
            rb2.AddForce(Vector3.up * (UIManager.instance.powerAmount) / 10 , ForceMode2D.Impulse);
           
        }
        Instantiate(explosion, shootFrom.transform.position, explosion.transform.rotation);
        target1.AddMember(slimeSpawned.transform, 2, 5);
        target1.RemoveMember(gameObject.transform);
        target1.RemoveMember(floor);
    }


    #region TODOLAUNCHSLIMEWITHUPGRADE
    

    private void LaunchWithPowerUpgrade()
    {
        EnableMesh();
        Debug.Log("POWERRRRRR");

        foreach (Rigidbody2D rbs in rbs)
        {
            rbs.gravityScale = 1;
            slimeSpawned.GetComponent<SlimeBall>().hasSpawned = true;
           
            rbs.AddForce(transform.right * ((UIManager.instance.powerAmount) + cannonStats.powerUpgrade.powerModifer) / 10, ForceMode2D.Impulse);       // TO DO Upgrade POWER 
            // Launch in the Air

            rbs.AddForce(Vector3.up * ((UIManager.instance.powerAmount) + cannonStats.powerUpgrade.powerModifer) / 10, ForceMode2D.Impulse);                // TO DO Upgrade POWER 

           
         }
        Instantiate(explosion, shootFrom.transform.position, explosion.transform.rotation);
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




    private void EnableMesh()
    {
        slimeSpawned.GetComponent<MeshRenderer>().enabled = true;
        for (int i = 0; i < sprites.Length; i++)
        {
            // Enables the Eyes 
            sprites[i].enabled = true;
        }
        if (PlayerManager.instance.CheckIfWorldUpgradeBought(1))
        {
            slimeSpawned.transform.Find("Jetpack").GetComponent<SpriteRenderer>().enabled = true;
        }

    }
}
