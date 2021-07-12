using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{


    // Can make array to spawn different type of slime
    [Header("Slime")]
    [SerializeField] private GameObject[] slime;

    [Header("Launch Settings")]
    [SerializeField] private float launchHeight;
    [SerializeField] private float launchSpeed;

    private Rigidbody2D rb;

    public void LaunchSlime()
    {
        GameObject slimeSpawned = Instantiate(slime[0], transform.position, transform.rotation);

        Rigidbody2D rb = slimeSpawned.GetComponent<Rigidbody2D>();

        rb.AddForce(transform.right * launchSpeed, ForceMode2D.Impulse);
        // Launch in the Air
        rb.AddForce(Vector3.up * launchHeight, ForceMode2D.Impulse);
    }


  public void SetLaunchSpeed(float amount)
    {
        launchSpeed = amount;
        LaunchSlime();
       
    }


}
