using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private int speedAmount;
    [SerializeField] private int heightAmount;
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
            
            if (!hasHit)
            {
                hasHit = true;
                if (PlayerManager.instance.slimeBall.GetComponent<SlimeBall>().slimeStats.multipleRbs)
                {
                    jellyRef = GameObject.Find(PlayerManager.instance.slimeBall.gameObject.name + "(Clone) Reference Points");
                    jellyRb = jellyRef.GetComponentsInChildren<Rigidbody2D>();
                    audioSource.PlayOneShot(audio);

                    foreach (Rigidbody2D rbs in jellyRb)
                    {
                        rbs.AddForce(transform.right * speedAmount, ForceMode2D.Impulse);
                        rbs.AddForce(Vector2.up * heightAmount * 2, ForceMode2D.Impulse);
                    }
                    

                }
               
                this.GetComponent<BoxCollider2D>().enabled = false;
                Invoke("SwitchOnCollider", 2f);
            }

        }
    }


    private void SwitchOnCollider()
    {
            this.GetComponent<BoxCollider2D>().enabled = true;
            Invoke("SwitchOnCollider", 2f);
        
    }
}



