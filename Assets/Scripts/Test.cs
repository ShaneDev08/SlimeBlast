using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int test;
    private SpriteRenderer sprite;

    public GameObject[] grassObjects;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer> ();

        if(test == 1)
        {
            transform.position = new Vector3(484.85f, transform.position.y, transform.position.z);
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
                Instantiate(grassObjects[Random.RandomRange(0, grassObjects.Length)], new Vector2(Random.RandomRange(0, 470), -2),transform.rotation);
            }
        }
        
        
        
        if(test == 2)
        {
            sprite.size = new Vector2(500, 7.4f);
        }
    }
}
