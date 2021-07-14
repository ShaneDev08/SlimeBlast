using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Launcher : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject slimeSpawned;
    private AudioSource audio;
    private float launchMultiplier;

    // TO DO 
    // Use upgrades class to add in upgrades to the launcher. Then we can check to see if upgrades have been unlocked and then use them
    private Upgrades[] upgrades = new Upgrades[5];      // Set the amount of upgrades we are going to put in


    public CinemachineTargetGroup target1;
    public CinemachineVirtualCamera cam;
    public AudioClip launchSound;
    public ObjectPool pool;
    public Transform shootFrom;
    
    private void Start()
    {
        EventManager.instance.LaunchSlime += LaunchSlime;
        audio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }
    public void LaunchSlime()
    {
        slimeSpawned = pool.GetObject();
        slimeSpawned.transform.position = shootFrom.transform.position;

       
        PlayerManager.instance.slimeInGame = slimeSpawned;
        Rigidbody2D rb = slimeSpawned.GetComponent<Rigidbody2D>();

        audio.PlayOneShot(launchSound);

        // If upgrades equals null then use default launch settings else use fire upgrade setting
        if (!CheckForPowerUpgrade())
        {
            LaunchWithNoUpgrades(rb);
            
        } else
        {
            LaunchWithPowerUpgrade();
        }
        

        //cam.LookAt = slimeSpawned.transform;
        //cam.Follow = slimeSpawned.transform;

    }


    // Added the jump here. If the abillity is enabled then we can show a button??
    public void Jump()
    {
        if (PlayerManager.abillities[0].isEnabled)
        {
            Debug.Log("Jump");
            slimeSpawned.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50f, ForceMode2D.Impulse);
        }
    }

    
    public void AddUpgrade(Upgrades upgrade)
    {
       for(int i = 0; i < upgrades.Length; i++)
        {
            if(upgrades[i] == null)
            {
                upgrades[i] = upgrade;
                break;
            }
        }
    }

    private bool CheckForPowerUpgrade()
    {
        if (upgrades[0] == null)
            return false;
        for(int i = 0; i < upgrades.Length;i++)
        {
            if(upgrades[i].name == "PowerUpgrade")
            {
                return true;
            }

            
        }

        return false;
    }


    #region LauncherWithOrWithoutUpgrades
    private void LaunchWithNoUpgrades(Rigidbody2D rb)
    {
        rb.AddForce(transform.right * UIManager.instance.powerAmount / 10, ForceMode2D.Impulse);
        // Launch in the Air
        rb.AddForce(Vector3.up * UIManager.instance.powerAmount / 10 , ForceMode2D.Impulse);

        target1.AddMember(slimeSpawned.transform, 1, 0);
    }

    private void LaunchWithPowerUpgrade()
    {

        PowerUpgrade power1 = null;
        for (int i = 0; i < upgrades.Length; i++)
        {
            if (upgrades[i].name == "PowerUpgrade")
            {
                power1 = (PowerUpgrade)upgrades[i];
            }
        }

        rb.AddForce(transform.right * UIManager.instance.powerAmount / 10 * power1.powerModifier, ForceMode2D.Impulse);
        // Launch in the Air
        rb.AddForce(Vector3.up * UIManager.instance.powerAmount / 10, ForceMode2D.Impulse);

        target1.AddMember(slimeSpawned.transform, 1, 0);
    }

    #endregion









}
