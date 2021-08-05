using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private Vector3 startPos;
    private GameObject slimeSpawnd;

    [Header("Plane Stats")]
    public float moveSpeed;
    public int amountToDamage;

    [Header("Misc")]
    public ObjectPool pool;
    public AudioClip hitSound;
    private bool hasSpawned = false;
    private bool hasBeenHit = false;

    private void Start()
    {
        startPos = this.transform.position;



    }
    private void Update()
    {
        if (!hasSpawned)
        {

            slimeSpawnd = pool.GetCurrentActiveObject();
            if (slimeSpawnd != null)
            {
                hasSpawned = true;
            }
        }

        this.transform.position += new Vector3(-1 *moveSpeed * Time.deltaTime, 0, 0);

        if (slimeSpawnd != null)
        {
            if (transform.position.x <= slimeSpawnd.transform.position.x - 25)
            {
                Debug.Log("Plane has gvone past");
                this.gameObject.transform.position = new Vector2(slimeSpawnd.transform.position.x + 50, transform.position.y);
                hasBeenHit = false;
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerManager.instance.slimeBall.GetComponent<SlimeBall>().slimeStats.multipleRbs && !hasBeenHit)
        {
            hasBeenHit = true;
            PlayerManager.instance.playerScore.ObstacalesHit += 1;
            collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().KillSlimeOnContact();
            
            collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().PlaySound(hitSound);
        }
        else
        {
            //collision.gameObject.GetComponent<SlimeBall>().PlaySound();
        }
    }
}
