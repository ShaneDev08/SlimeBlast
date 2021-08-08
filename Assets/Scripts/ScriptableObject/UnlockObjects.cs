using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[CreateAssetMenu(menuName ="Unlock/Unlock")]
public class UnlockObjects : ScriptableObject
{
   
[Header("UnlockHolderObjects")]
    public Sprite slimeSprite;
    public string slimeName;
    public string slimeUnlockValue;
    public bool isUnlocked;

[Header("UnlockHolderID")]
    public int slimeID;

}
