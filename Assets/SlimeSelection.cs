using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject slimePrefab;

    public void SetSlime()
    {
        if(slimePrefab.GetComponent<SlimeBall>().slimeStats.slimeBought.isUnlocked) PlayerManager.instance.slimeBall = slimePrefab;
    }

    public void ViewStats()
    {
        Debug.Log("Show Stats");
    }
}
