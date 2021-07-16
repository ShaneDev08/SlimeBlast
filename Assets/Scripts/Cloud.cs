using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    private Transform startPos;

    private void Start()
    {
        startPos = transform;
        Debug.Log(startPos.transform.position.x);
        Debug.Log(transform.position.x);
    }
    private void Update()
    {
        //this.transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);
        
        if(transform.position.x <= -10)
        {
           
            this.gameObject.transform.position =  new Vector3(startPos.position.x,startPos.position.y,startPos.position.z);
        }
           
        
    }
}
