using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="SlimeCharacter")]
public class SlimeStats : ScriptableObject {
    


    [Header("Slime Main Stats")]
    public int slimeHealth;
    public float slimeBounciness;
    public float slimeWeight;

    [Header("Slime Secondary Stats")]
    public string slimeName;

    

    [Header("SlimeObjectReferences")]
    public Sprite slimeSprite;
    public Color slimeBackground;
    public AudioClip[] slimeNoises;
    public bool multipleRbs;

}
