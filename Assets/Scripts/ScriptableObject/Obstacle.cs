using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Obstacle")]
public class Obstacle : ScriptableObject
{

    public enum Type
    {
        BouncePad,
        Rock
    }
    public Type type;
    public float speedAmount;
    public float heightAmount;
}
