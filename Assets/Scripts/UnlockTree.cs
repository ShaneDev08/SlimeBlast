using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTree : MonoBehaviour
{
    public static UnlockTree instance;

    private void Awake() => instance = this;

    //[SerializeField] private GameObject unlockHolder;

    private List<GameObject> holders = new List<GameObject>();



    public void CheckForBoughtTree(int[] connectedIds)
    {
        foreach(GameObject unlockHolder in holders)
        {
            int currentID = 0;
            currentID = unlockHolder.GetComponent<UnlockSkills>().currentId;

            for(int i = 0; i < connectedIds.Length; i++)
            {
                if (currentID == i)
                {
                    //unlockHolder.SetActive(true);
                }
            }
            
        }
    }

}


        //                  1
        //      2                          3
        // 4           6              5         7 
//  8        10     12   14       9     11   13   15
