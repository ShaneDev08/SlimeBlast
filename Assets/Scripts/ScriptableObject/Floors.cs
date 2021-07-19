using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Floors")]
public class Floors : ScriptableObject
{
    public enum Type
    {
        Grass,
        Ice,
        Sand
    }
    public GameObject[] objects;
    public Type type;
}
