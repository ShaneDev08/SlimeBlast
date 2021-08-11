using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName ="UnlockSkill")]
public class UnlockSkills : ScriptableObject
{
    [Header("Unlock Properties")]
    public string titleText;
    public string descriptionText;
    public int upgradeValue;
    public bool isBought;
    public Sprite unlockImage;

    [Header("Tree Connector")]
    public int currentId;
    public int[] connectedIds;
  



}
