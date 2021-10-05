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
    [SerializeField] private GameObject bouncePads;
    [SerializeField] private GameObject extraSlime;
    [SerializeField] private GameObject extraMoney;
    [SerializeField] private GameObject fan;
    [SerializeField] private GameObject slimeSpawner;

    [Header("Obstcals")]
    [SerializeField] private GameObject rocks;

    // Money


    [Header("Amount To Spawn")]
    [SerializeField] private int bouncePadsToSpawn;
    [SerializeField] private int extraSlimeToSpawn;
    [SerializeField] private int extraMoneyToSpawn;
    [SerializeField] private int fansToSpawns;
    [SerializeField] private int slimeSpawnersToSpawn;
    [SerializeField] private int rocksToSpawn;







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


        // 0 is bounce pads
        // 1 is jetpack so break.
        // 2 is SlimeSpawner
        // 3 is fan
        // 4 is extra slime
        // 5 is extra money
        for (int i = 0; i < PlayerManager.instance.upgradeForWorld.Count; i++)
        {
            if (PlayerManager.instance.CheckIfWorldUpgradeBought(i))
            {
                switch (i)
                {
                    // bounce pads
                    case 0:
                        SpawnBouncePads();
                        break;
                    // Jet pack
                    case 1:
                        break;
                    // Slime Spawner
                    case 2:
                        SpawnSlimeSpawner();
                        break;
                    // Fan
                    case 3:
                        SpawnFans();
                        break;
                    // Extra Slime
                    case 4:
                        SpawnExtraSlime();
                        break;
                    // Extra Money
                    case 5:
                        SpawnMoneyBags();
                        break;

                    
                }
            }
        }

        //if (PlayerManager.shopUpgrades["SlimePickup"].isEnabled)
        //{
        //    SpawnExtraSlime();
        //}

        //if (PlayerManager.shopUpgrades["MoneyPickup"].isEnabled)
        //{
        //    SpawnMoneyBags();
        //}

        SpawnRocks();

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void CreateLevel( FloorHolder gameFloor)
    {
        sprite.size = new Vector2(distanceToSpan, 7.25f);

        if (gameFloor.floor.type == Floors.Type.Grass)
        {
            for (int i = 0; i < 25; i++)
            {
                int randomNumber = Random.Range(0, gameFloor.floor.objects.Length);
             GameObject go =   Instantiate(gameFloor.floor.objects[randomNumber], new Vector2(Random.Range(5, distanceToSpan), gameFloor.floor.objects[randomNumber].transform.position.y), gameFloor.floor.objects[randomNumber].gameObject.transform.rotation);
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

    void SpawnRocks()
    {
        for (int i = 0; i < rocksToSpawn; i++)

        {
            GameObject go = Instantiate(rocks, new Vector2((float)Random.Range(10, distanceToSpan * floors.Length), rocks.transform.position.y), rocks.transform.rotation);
            go.transform.parent = helperObjects.transform;
        }
    }

    void SpawnFans()
    {
        for (int i = 0; i < fansToSpawns; i++)

        {
            GameObject go = Instantiate(fan, new Vector2((float)Random.Range(10, distanceToSpan * floors.Length), (float)Random.Range(0,300)), fan.transform.rotation);
            go.transform.parent = helperObjects.transform;
        }
    }

    void SpawnSlimeSpawner()
    {
        for (int i = 0; i < slimeSpawnersToSpawn; i++)

        {
            GameObject go = Instantiate(slimeSpawner, new Vector2((float)Random.Range(10, distanceToSpan * floors.Length), slimeSpawner.transform.position.y), slimeSpawner.transform.rotation);
            go.transform.parent = helperObjects.transform;
        }
    }
}
