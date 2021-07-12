using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public Obstacle obstacle;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Player"))
        {
            
            if (obstacle.type == Obstacle.Type.BouncePad)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * obstacle.speedAmount, ForceMode2D.Impulse);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * obstacle.heightAmount, ForceMode2D.Impulse);
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



