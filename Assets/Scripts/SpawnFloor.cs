using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloor : MonoBehaviour
{
    private SpriteRenderer sprite;
    //public Floors floor;

    [Header("Floors")]
    public GameObject[] floors;

    [Header("Spawning Calculations")]
    [Tooltip("Distance the set of floors span across")]
    public int distanceToSpan;


    [Header("ParentObject")]
    public GameObject floorParent;
    public GameObject helperObjects;

    [Header("Helpers")]
    public GameObject bouncePads;
    public GameObject extraSlime;
    public GameObject extraMoney;
    // Money


    [Header("Amount To Spawn")]
    public int bouncePadsToSpawn;
    public int extraSlimeToSpawn;
    public int extraMoneyToSpawn;






    // Start is called before the first frame update
    void Start()
    {
        
        foreach (GameObject floor in floors)
        {
            sprite = floor.GetComponent<SpriteRenderer>();
            FloorHolder gameFloor = floor.GetComponent<FloorHolder>();
            if (gameFloor.floor.type == Floors.Type.Ice)
            {
                floor.transform.position = new Vector3(distanceToSpan - floors[0].transform.position.x , floor.transform.position.y, floor.transform.position.z);
                //floor.transform.position = new Vector3(484.85f, floor.transform.position.y, floor.transform.position.z);
                sprite.size = new Vector2(distanceToSpan, 11.78f);
            }

            else if (gameFloor.floor.type == Floors.Type.Sand)
            {
                floor.transform.position = new Vector3(floors[1].transform.position.x + distanceToSpan, floor.transform.position.y, floor.transform.position.z);
            }
            CreateLevel(gameFloor);
            
        }
        SpawnBouncePads();
        SpawnExtraSlime();
        SpawnMoneyBags();

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void CreateLevel( FloorHolder gameFloor)
    {
        sprite.size = new Vector2(distanceToSpan, 9.373164f);

        if (gameFloor.floor.type == Floors.Type.Grass)
        {
            for (int i = 0; i < 25; i++)
            {
                int randomNumber = Random.Range(0, gameFloor.floor.objects.Length);
             GameObject go =   Instantiate(gameFloor.floor.objects[randomNumber], new Vector2(Random.Range(5, distanceToSpan), gameFloor.floor.objects[randomNumber].transform.position.y), transform.rotation);
                go.transform.parent = floorParent.transform;
            }
        }

        if (gameFloor.floor.type == Floors.Type.Ice)
        {
            for (int i = 0; i < 25; i++)
            {
                int randomNumber = Random.Range(0, gameFloor.floor.objects.Length);
                GameObject go = Instantiate(gameFloor.floor.objects[randomNumber], new Vector2(Random.Range(distanceToSpan, distanceToSpan * 2), gameFloor.floor.objects[randomNumber].transform.position.y), transform.rotation);
                go.transform.parent = floorParent.transform;
            }
        }



        if (gameFloor.floor.type == Floors.Type.Sand)
        {
            sprite.size = new Vector2(distanceToSpan, 7.4f);

            for (int i = 0; i < 25; i++)
            {
                int randomNumber = Random.Range(0, gameFloor.floor.objects.Length);
                GameObject go = Instantiate(gameFloor.floor.objects[randomNumber], new Vector2(Random.Range(distanceToSpan *2, distanceToSpan * 3), gameFloor.floor.objects[randomNumber].transform.position.y), transform.rotation);
                go.transform.parent = floorParent.transform;
            }
        }
    }

    void SpawnBouncePads()
    {
        for(int i = 0; i < bouncePadsToSpawn; i++ )

        {
           GameObject go =  Instantiate(bouncePads, new Vector2((float)Random.Range(10, distanceToSpan * floors.Length), bouncePads.transform.position.y), bouncePads.transform.rotation);
            go.transform.parent = helperObjects.transform;
        }
    }

    void SpawnExtraSlime()
    {
        for (int i = 0; i < extraSlimeToSpawn; i++)

        {
            GameObject go = Instantiate(extraSlime, new Vector2((float)Random.Range(10, distanceToSpan * floors.Length), extraSlime.transform.position.y), extraSlime.transform.rotation);
            go.transform.parent = helperObjects.transform;
        }
    }

    void SpawnMoneyBags()
    {
        for (int i = 0; i < extraMoneyToSpawn; i++)

        {
            GameObject go = Instantiate(extraMoney, new Vector2((float)Random.Range(10, distanceToSpan * floors.Length), extraMoney.transform.position.y), extraMoney.transform.rotation);
            go.transform.parent = helperObjects.transform;
        }
    }
}
