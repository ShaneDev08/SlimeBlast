using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Achievement/Achievements")]
public class Achievements : ScriptableObject
{
    public string nameOfAchievement;
    public enum Type
    {
        Distance,
        Height,
        Collected
    }
    public Type type;

    public int amountToScore;
    public int moneyToGive;
    public bool hasPassed = false;
    public bool hasCollected = false;
}
