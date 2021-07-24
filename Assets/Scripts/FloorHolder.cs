using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorHolder : MonoBehaviour
{
    public Floors floor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerManager.instance.slimeBall.GetComponent<SlimeBall>().slimeStats.multipleRbs)
        {
            collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().TakeDamage(30);
            collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().PlaySound();
        }
        else
        {
            collision.gameObject.GetComponent<SlimeBall>().PlaySound();
        }

    }
}
