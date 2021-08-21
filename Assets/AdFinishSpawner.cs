using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdFinishSpawner : MonoBehaviour

{
    public static AdFinishSpawner instance;
    private ObjectPool objectPool;
    public Transform startPos;
    private GameObject slimeSpawned;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        EventManager.instance.RoundOver += AdRestart;
        objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AdRestart()
    {
        Debug.Log("Event Fired");
        slimeSpawned = objectPool.GetObject();
        slimeSpawned.transform.position = startPos.transform.position;
        slimeSpawned.GetComponent<SlimeBall>().Restart();
    }
}
