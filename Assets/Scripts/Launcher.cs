using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Launcher : MonoBehaviour
{


    // Can make array to spawn different type of slime
    [Header("Slime")]
    [SerializeField] private GameObject slime;

    [Header("Launch Settings")]
    [SerializeField] private float launchHeight;
    [SerializeField] private float launchSpeed;

    private Rigidbody2D rb;


    public CinemachineVirtualCamera cam;
    
    private void Start()
    {
        EventManager.instance.LaunchSlime += LaunchSlime;
    }
    public void LaunchSlime()
    {
        GameObject slimeSpawned = Instantiate(slime, transform.position, transform.rotation);

        Rigidbody2D rb = slimeSpawned.GetComponent<Rigidbody2D>();

        rb.AddForce(transform.right * UIManager.instance.powerAmount, ForceMode2D.Impulse);
        // Launch in the Air
        rb.AddForce(Vector3.up * UIManager.instance.powerAmount, ForceMode2D.Impulse);
        
        cam.LookAt = slimeSpawned.transform;
        cam.Follow = slimeSpawned.transform;
    }


 


}
