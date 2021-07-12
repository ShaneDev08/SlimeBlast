using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SlimeBall : MonoBehaviour
{
    private CinemachineTargetGroup target1;

    private void Start()
    {
        target1 = GameObject.Find("TargetGroup").GetComponent<CinemachineTargetGroup>();
    }
    private void Update()
    {

        Invoke("KillSlime", 5);

    }


    private void KillSlime()
    {
        target1.RemoveMember(this.transform);
    }
}
