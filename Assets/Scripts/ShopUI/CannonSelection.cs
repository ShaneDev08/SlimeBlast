using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSelection : MonoBehaviour
{
    [SerializeField] private GameObject cannon;
    


    public void OnCannonSelect()
    {
        PlayerManager.instance.cannon = this.cannon;
    }
}
