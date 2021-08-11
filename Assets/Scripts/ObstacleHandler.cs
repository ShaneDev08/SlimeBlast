using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{

    public Obstacle obstacle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = obstacle.sprites[1];
            collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().KillSlimeOnContact();
        }
    }


}
