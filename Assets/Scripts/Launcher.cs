using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Launcher : MonoBehaviour
{


    // Can make array to spawn different type of slime
    [Header("Slime")]
    //[SerializeField] private GameObject slime;

    //[Header("Launch Settings")]
    ////[SerializeField] private float launchHeight;
    ////[SerializeField] private float launchSpeed;

    private Rigidbody2D rb;
    public CinemachineTargetGroup target1;


    public CinemachineVirtualCamera cam;

    private GameObject slimeSpawned;
    
    private void Start()
    {
        EventManager.instance.LaunchSlime += LaunchSlime;
    }
    public void LaunchSlime()
    {
         slimeSpawned = Instantiate(PlayerManager.instance.slimeBall, transform.position, transform.rotation);
        PlayerManager.instance.slimeInGame = slimeSpawned;
        Rigidbody2D rb = slimeSpawned.GetComponent<Rigidbody2D>();

        rb.AddForce(transform.right * UIManager.instance.powerAmount, ForceMode2D.Impulse);
        // Launch in the Air
        rb.AddForce(Vector3.up * UIManager.instance.powerAmount, ForceMode2D.Impulse);

        target1.AddMember(slimeSpawned.transform,1,0);
        

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

   





}
