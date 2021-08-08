using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorHolder : MonoBehaviour
{

    [Header("Damage Amount")]
    [SerializeField] private int damage;
    public Floors floor;
    private bool hasHit = false;
    private float startTime;
    private float endTime = 4f;
    private bool hasStoppedMoving = false;


    private void Start()
    {
        StartCoroutine(CheckIfStopedMoving());
        startTime = 1f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerManager.instance.slimeBall.GetComponent<SlimeBall>().slimeStats.multipleRbs && !hasHit)
        {
            collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().TakeDamage(damage,false);
            collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().PlaySound();
            hasHit = true;
            Invoke("ResetHit", 0.1f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        hasStoppedMoving = true;

        if (startTime >= endTime)
        {
            if (collision.gameObject.CompareTag("Player") && PlayerManager.instance.slimeBall.GetComponent<SlimeBall>().slimeStats.multipleRbs && !hasHit)
            {
                collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().KillSlimeOnContact();
                collision.gameObject.GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<SlimeBall>().PlaySound();
                hasHit = true;
                Invoke("ResetHit", 0.1f);
            }
        }
       

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        startTime = 1f;
    }

       
        


    

    IEnumerator CheckIfStopedMoving()
    {
        while (true)
        {
            if (hasStoppedMoving)
            {
                Debug.Log("Start Time is " + startTime);
                startTime += 1;
            }
            yield return new WaitForSeconds(1);
        }

    }





    private void ResetHit()
    {
        hasHit = false;
    }
}
