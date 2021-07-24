using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloor : MonoBehaviour
{
    private SpriteRenderer sprite;
    //public Floors floor;

    public GameObject[] floors;

    public GameObject bouncePads;
    public GameObject floorParent;
    public GameObject bounceParent;
    public int amountToSpawn;


    // Start is called before the first frame update
    void Start()
    {
        
        foreach (GameObject floor in floors)
        {
            sprite = floor.GetComponent<SpriteRenderer>();
            FloorHolder gameFloor = floor.GetComponent<FloorHolder>();
            if (gameFloor.floor.type == Floors.Type.Ice)
            {
                floor.transform.position = new Vector3(floors[0].transform.position.x + 500 -5, floor.transform.position.y, floor.transform.position.z);
                //floor.transform.position = new Vector3(484.85f, floor.transform.position.y, floor.transform.position.z);
                sprite.size = new Vector2(500, 11.78f);
            }

            else if (gameFloor.floor.type == Floors.Type.Sand)
            {
                floor.transform.position = new Vector3(floors[1].transform.position.x + 500, floor.transform.position.y, floor.transform.position.z);
            }
            CreateLevel(gameFloor);
            
        }
        SpawnBouncePads();

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void CreateLevel( FloorHolder gameFloor)
    {
        sprite.size = new Vector2(500, 9.373164f);

        if (gameFloor.floor.type == Floors.Type.Grass)
        {
            for (int i = 0; i < 25; i++)
            {
                int randomNumber = Random.Range(0, gameFloor.floor.objects.Length);
             GameObject go =   Instantiate(gameFloor.floor.objects[randomNumber], new Vector2(Random.Range(5, 470), gameFloor.floor.objects[randomNumber].transform.position.y), transform.rotation);
                go.transform.parent = floorParent.transform;
            }
        }

        if (gameFloor.floor.type == Floors.Type.Ice)
        {
            for (int i = 0; i < 25; i++)
            {
                int randomNumber = Random.Range(0, gameFloor.floor.objects.Length);
                GameObject go = Instantiate(gameFloor.floor.objects[randomNumber], new Vector2(Random.Range(490, 960), gameFloor.floor.objects[randomNumber].transform.position.y), transform.rotation);
                go.transform.parent = floorParent.transform;
            }
        }



        if (gameFloor.floor.type == Floors.Type.Sand)
        {
            sprite.size = new Vector2(500, 7.4f);

            for (int i = 0; i < 25; i++)
            {
                int randomNumber = Random.Range(0, gameFloor.floor.objects.Length);
                GameObject go = Instantiate(gameFloor.floor.objects[randomNumber], new Vector2(Random.Range(980, 1460), gameFloor.floor.objects[randomNumber].transform.position.y), transform.rotation);
                go.transform.parent = floorParent.transform;
            }
        }
    }

    void SpawnBouncePads()
    {
        for(int i = 0; i < amountToSpawn; i++ )

        {
           GameObject go =  Instantiate(bouncePads, new Vector2((float)Random.Range(10, 2000), bouncePads.transform.position.y), bouncePads.transform.rotation);
            go.transform.parent = bounceParent.transform;
        }
    }
}
