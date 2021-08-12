using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCannon : MonoBehaviour
{
   
    void Start()
    {
        Instantiate(PlayerManager.instance.cannon);
    }

   
}
