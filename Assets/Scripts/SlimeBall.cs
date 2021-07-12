using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SlimeBall : MonoBehaviour
{
    private CinemachineTargetGroup target1;
    public GameObject flag;
    private bool hasStopedMoving = false;
    int score;
    private void Start()
    {
        target1 = GameObject.Find("TargetGroup").GetComponent<CinemachineTargetGroup>();
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
            
        }

    }


    private void KillSlime()
    {
        target1.RemoveMember(this.transform);
        Destroy(this.gameObject);
    }
}
