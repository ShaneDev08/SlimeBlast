using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Unlock/UnlockList")]
public class UnlockObjectList : ScriptableObject
{
    
    public List<UnlockObjects> unlockList = new List<UnlockObjects>();

}
