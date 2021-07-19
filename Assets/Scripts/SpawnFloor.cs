using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloor : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Floors floor;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        if (floor.type == Floors.Type.Ice)
        {
            transform.position = new Vector3(484.85f, transform.position.y, transform.position.z);
            sprite.size = new Vector2(500, 11.78f);
        }

        else if (floor.type == Floors.Type.Sand)
        {
            transform.position = new Vector3(984.7f, transform.position.y, transform.position.z);
        }
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void CreateLevel()
    {
        sprite.size = new Vector2(500, 9.373164f);

        if (floor.type == Floors.Type.Grass)
        {
            for (int i = 0; i < 25; i++)
            {
                int randomNumber = Random.RandomRange(0, floor.objects.Length);
                Instantiate(floor.objects[randomNumber], new Vector2(Random.RandomRange(0, 470), floor.objects[randomNumber].transform.position.y), transform.rotation);
            }
        }

        if (floor.type == Floors.Type.Ice)
        {
            for (int i = 0; i < 25; i++)
            {
                int randomNumber = Random.RandomRange(0, floor.objects.Length);
                Instantiate(floor.objects[randomNumber], new Vector2(Random.RandomRange(490, 960), floor.objects[randomNumber].transform.position.y), transform.rotation);
            }
        }



        if (floor.type == Floors.Type.Sand)
        {
            sprite.size = new Vector2(500, 7.4f);

            for (int i = 0; i < 25; i++)
            {
                int randomNumber = Random.RandomRange(0, floor.objects.Length);
                Instantiate(floor.objects[randomNumber], new Vector2(Random.RandomRange(980, 1460), floor.objects[randomNumber].transform.position.y), transform.rotation);
            }
        }
    }
}
