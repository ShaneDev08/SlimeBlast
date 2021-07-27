using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    [Header("Slime Modifiers")]
    public int health;
    public int slimeCollected = 0;
    public int obstaclesHit = 0;
    [Header("Sounds")]
    public AudioClip collectionSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerManager.instance.slimeBall.GetComponent<SlimeBall>().slimeStats.multipleRbs)
        {
            collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().AddSlime(health);
            slimeCollected ++;
            PlayerManager.instance.playerScore.SlimeCollected += 1;
            Destroy(gameObject);
            collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().PlaySound(collectionSound);
        }
        else
        {
            //collision.gameObject.GetComponent<SlimeBall>().PlaySound();
        }

    }
}


