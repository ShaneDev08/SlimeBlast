using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    [Header("Slime Modifiers")]
    public int health;

    [Header("Sounds")]
    public AudioClip collectionSound;

    private bool hasBeenCollected = false;

    public bool spawnFromSpawner = false;

    private float aliveTime = 5f;
    private float startTime;


    private void OnEnable()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if(spawnFromSpawner && Time.time - startTime >= aliveTime)
        {
            gameObject.SetActive(false);
        }    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerManager.instance.slimeBall.GetComponent<SlimeBall>().slimeStats.multipleRbs && !hasBeenCollected)
        {
            hasBeenCollected = true;
            collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().AddSlime(health);

            PlayerManager.instance.playerScore.SlimeCollected += 1;
            
            collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().PlaySound(collectionSound);
            gameObject.SetActive(false);
        }
        else
        {
            //collision.gameObject.GetComponent<SlimeBall>().PlaySound();
        }

    }
}


