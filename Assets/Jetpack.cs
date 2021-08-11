using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
     private GameObject slime;
    [SerializeField] private Transform spawnPoint;
    private ObjectPool pool;
    public bool usingJetPack = false;
    [SerializeField] ParticleSystem particleSystem;

    private void Start()
    {
        pool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
    }
    private void Update()
    {

        
       if(usingJetPack)
        {
           
            particleSystem.Play();
        }

       else
        {
            particleSystem.Stop();
        }
    }

}






