using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SlimeBall : MonoBehaviour
{
    private CinemachineTargetGroup target1;
    private bool hasStopedMoving = false;
    private int score;
    private AudioSource audioSource;


    // Flag to spawn as reminder where you last hit
    public GameObject flag;
    // Scriptable object to hold all the slime stats
    public SlimeStats slimeStats;

    

   
    private void Start()
    {
        target1 = GameObject.Find("TargetGroup").GetComponent<CinemachineTargetGroup>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
       
        if((int)transform.position.x > score)
        score = (int)transform.position.x;

        UIManager.instance.UpdateScoreText(score);

        if(GetComponent<Rigidbody2D>().IsSleeping() && !hasStopedMoving)
        {
            hasStopedMoving = true;
         GameObject obj =  Instantiate(flag, transform.position, flag.transform.rotation);
            //target1.AddMember(obj.transform,1,0);

            // if score is over 100 add 100 money
            if(score > 100)
            {
                PlayerManager.money = 100;
            }
            KillSlime();
            hasStopedMoving = false;
            
        }

    }


    private void KillSlime()
    {
        target1.RemoveMember(this.transform);
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("BouncingPad"))
            {
                audioSource.PlayOneShot(slimeStats.slimeNoises[1]);
            }
            else
            {
                audioSource.PlayOneShot(slimeStats.slimeNoises[0]);
            }
        }
    }
}
