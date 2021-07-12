using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    // Make this script a singleton
    public static UIManager instance;


    [Header("FireFunction")]
    [SerializeField] Button startButton;
    [SerializeField] Image powerImage;

    public float powerAmount;




    // Makes this a singleton using instance as the var
    private void Awake()
    {
        instance = this;
    }
    //[SerializeField] Button fireButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
