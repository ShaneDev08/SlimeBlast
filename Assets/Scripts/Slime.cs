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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerManager.instance.slimeBall.GetComponent<SlimeBall>().slimeStats.multipleRbs && !hasBeenCollected)
        {
            hasBeenCollected = true;
            collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().AddSlime(health);

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


