using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    private Vector3  startPos;
    private GameObject slimeSpawnd;
    public ObjectPool pool;
    private bool hasSpawned = false;

    private void Start()
    {
        startPos = this.transform.position;

        

    }
    private void Update()
    {
        if (!hasSpawned)
        {
            
            slimeSpawnd = pool.GetCurrentActiveObject();
            if(slimeSpawnd != null)
            {
                hasSpawned = true;
            }
        }

        this.transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);

        if (slimeSpawnd != null)
        {
            if (transform.position.x <= slimeSpawnd.transform.position.x - 25)
            {
                Debug.Log("Plane has gvone past");
                this.gameObject.transform.position = new Vector2(slimeSpawnd.transform.position.x + 50, transform.position.y);
            }
        }
           
        
    }
}
