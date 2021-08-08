using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[CreateAssetMenu(menuName ="Unlock")]
public class UnlockObjects : ScriptableObject
{
   
[Header("UnlockHolderObjects")]
    public Sprite unlockHolder;
    public Sprite slimeSprite;
    public TextMeshProUGUI slimeName;
    public TextMeshProUGUI slimeUnlockValue;

[Header("UnlockHolderID")]
    public int slimeID;

}
