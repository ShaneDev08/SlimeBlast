using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{

    [Header("Misc")]
   [SerializeField] private bool isEnabled = false;
    [SerializeField]  private  ObjectPool pool;
    [SerializeField] private Transform spawnPoint;
    private GameObject slimeSpawnd;


    void Start()
    {
        StartCoroutine("SpawnSlime");
    }

    // Update is called once per frame
    void Update()
    {
        slimeSpawnd = pool.GetCurrentActiveObject();
        if (slimeSpawnd != null)
        {
            if(slimeSpawnd.transform.position.x > transform.position.x -30)
            {
                isEnabled = true;
            } 
            else if (slimeSpawnd.transform.position.x > transform.position.x)
            {
                isEnabled = false;
            }
        }

        if(isEnabled)
        {
            

        }
    }

    IEnumerator SpawnSlime()
    {
        Debug.Log("started SPAWNING");
        while (true)
        {

            if (isEnabled)
            {
                GameObject slime = pool.GetSlimeObject();
                slime.GetComponent<Slime>().spawnFromSpawner = true;

                slime.transform.position = spawnPoint.transform.position;
            }
            yield return new WaitForSeconds(0.7f);
        }
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerManager.instance.slimeBall.GetComponent<SlimeBall>().slimeStats.multipleRbs)
        {
            collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().AddHeight();
        }
    }
}
