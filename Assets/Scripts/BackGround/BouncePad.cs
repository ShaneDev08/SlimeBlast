using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public Obstacle obstacle;
    private AudioSource audioSource;
    public AudioClip audio;

    private Rigidbody2D[] jellyRb;
    private GameObject jellyRef;
    private bool hasHit;

    private void Start()
    {
        audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Player"))
        {
            
            if (obstacle.type == Obstacle.Type.BouncePad && !hasHit)
            {
                hasHit = true;
                if (PlayerManager.instance.slimeBall.GetComponent<SlimeBall>().slimeStats.multipleRbs)
                {
                    jellyRef = GameObject.Find(PlayerManager.instance.slimeBall.gameObject.name + "(Clone) Reference Points");
                    jellyRb = jellyRef.GetComponentsInChildren<Rigidbody2D>();
                    audioSource.PlayOneShot(audio);

                    //jellyRb[0].AddForce(transform.right * obstacle.speedAmount, ForceMode2D.Impulse);
                    //jellyRb[0].AddForce(Vector2.up * obstacle.heightAmount * 2, ForceMode2D.Impulse);

                    foreach (Rigidbody2D rbs in jellyRb)
                    {
                        rbs.AddForce(transform.right * obstacle.speedAmount, ForceMode2D.Impulse);
                        rbs.AddForce(Vector2.up * obstacle.heightAmount * 2, ForceMode2D.Impulse);
                    }
                    

                }
                else
                {
                   Rigidbody2D rb =  collision.gameObject.GetComponent<Rigidbody2D>();
                    audioSource.PlayOneShot(audio);
                    rb.AddForce(transform.right * obstacle.speedAmount, ForceMode2D.Impulse);
                    rb.AddForce(Vector2.up * obstacle.heightAmount * 4, ForceMode2D.Impulse);

                }
                //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * obstacle.speedAmount, ForceMode2D.Impulse);
                //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * obstacle.heightAmount, ForceMode2D.Impulse);
                this.GetComponent<BoxCollider2D>().enabled = false;
                Invoke("SwitchOnCollider", 2f);
            }
            else if((obstacle.type == Obstacle.Type.Rock))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                this.GetComponent<CapsuleCollider2D>().enabled = false;
                Invoke("SwitchOnCollider", 2f);
            }

            

        }
    }


    private void SwitchOnCollider()
    {
        if (obstacle.type == Obstacle.Type.BouncePad)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            Invoke("SwitchOnCollider", 2f);
        }
        else if ((obstacle.type == Obstacle.Type.Rock))
        {
            this.GetComponent<CapsuleCollider2D>().enabled = true;
            Invoke("SwitchOnCollider", 2f);
        }
    }
}



