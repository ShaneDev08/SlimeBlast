using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public GameObject slimePrefab;

    [SerializeField] private  int createOnStart;
    [SerializeField] private int amountOfSlimeToSpawn;


    private List<GameObject> pooledObjs = new List<GameObject>();
    private List<GameObject> slimeSpawnerSlime = new List<GameObject>();

    private void Start()
    {

        for (int x = 0; x < createOnStart; x++)
        {
            CreateNewObject();
        }

        for (int x = 0; x < amountOfSlimeToSpawn; x++)
        {
            CreateNewSlimeObject();
        }

    }
        private GameObject CreateNewObject()
        {
            GameObject obj = Instantiate(PlayerManager.instance.slimeBall);
            obj.SetActive(false);
            pooledObjs.Add(obj);

            return obj;
        }

    private GameObject CreateNewSlimeObject()
    {
        GameObject obj = Instantiate(slimePrefab);
        obj.SetActive(false);
        slimeSpawnerSlime.Add(obj);
            return obj;
    }

    // Get or activate Slime
    public GameObject GetSlimeObject()
    {
        GameObject obj = slimeSpawnerSlime.Find(x => x.activeInHierarchy == false);

        if (obj == null)
        {
            obj = CreateNewSlimeObject();
        }

        obj.SetActive(true);

        return obj;
    }



    public GameObject GetObject()
    {
        GameObject obj = pooledObjs.Find(x => x.activeInHierarchy == false);

        if (obj == null)
        {
            obj = CreateNewObject();
        }

        obj.SetActive(true);

        return obj;
    }

    public GameObject GetCurrentActiveObject()
    {
        foreach(GameObject obj in pooledObjs)
        {
            if(obj.activeSelf)
            {
                return obj;
            }
        }

        return null;
    }
}
