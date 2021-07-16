using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int test;
    private SpriteRenderer sprite;

    public GameObject[] grassObjects;
    public GameObject[] iceObjects;
    public GameObject[] sandObjects;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer> ();

        if(test == 1)
        {
            transform.position = new Vector3(484.85f, transform.position.y, transform.position.z);
            sprite.size = new Vector2(500, 11.78f);
        }

        else if (test == 2)
        {
            transform.position = new Vector3(984.7f, transform.position.y, transform.position.z);
        }
        CreateLevel();
    }

    // Update is called once per frame
   void CreateLevel()
    {
        sprite.size = new Vector2(500, 9.373164f);

        if(test == 0)
        {
            for(int i = 0; i < 25; i++)
            {
                int randomNumber = Random.RandomRange(0, grassObjects.Length);
                Instantiate(grassObjects[randomNumber], new Vector2(Random.RandomRange(0, 470), grassObjects[randomNumber].transform.position.y), transform.rotation);
            }
        }

        if(test == 1)
        {
            for (int i = 0; i < 25; i++)
            {
                int randomNumber = Random.RandomRange(0, iceObjects.Length);
                Instantiate(iceObjects[randomNumber], new Vector2(Random.RandomRange(490, 960), iceObjects[randomNumber].transform.position.y), transform.rotation);
            }
        }
        
        
        
        if(test == 2)
        {
            sprite.size = new Vector2(500, 7.4f);

            for (int i = 0; i < 25; i++)
            {
                int randomNumber = Random.RandomRange(0, sandObjects.Length);
                Instantiate(sandObjects[randomNumber], new Vector2(Random.RandomRange(980, 1460), sandObjects[randomNumber].transform.position.y), transform.rotation);
            }
        }
    }
}
