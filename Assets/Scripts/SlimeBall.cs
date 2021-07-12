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
            Instantiate(flag, transform.position, flag.transform.rotation);
            KillSlime();
            
        }

    }


    private void KillSlime()
    {
        target1.RemoveMember(this.transform);
        Destroy(this.gameObject);
    }
}
