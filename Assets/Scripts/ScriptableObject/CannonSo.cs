using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Cannon/Cannon")]
public class CannonSo : ScriptableObject
{
    [Header("Cannon Stats")]
    public string nameOfCannon;
    [Tooltip("Starting Power for the Cannon")]
    public int power;
    public int value;
    

    [Header("ID")]
    public int id;

    public CannonPowerUpgrade powerUpgrade;
}
