using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SlimeBall : MonoBehaviour
{

    // Scriptable object to hold all the slime stats
    public SlimeStats slimeStats;
    public bool hasSpawned;
    // Flag to spawn as reminder where you last hit
    public GameObject flag;


    // Rigidbodys
    private Rigidbody2D standardSlimeRb;
    private Rigidbody2D[] rbs;
    //private Rigidbody2D mainRB;

    // Game Components 
    private CinemachineTargetGroup target1;
    private AudioSource audioSource;
    private GameObject tank;
    private GameObject floor;
    private GameObject jellyRef;
    private GameObject uiControl;
    private UnityJellySprite jellyScript;

    // Script Variables
    private bool hasStopedMoving = false;
    private int score;
    private bool hasSpawndFlag;
    private bool hasMultipleRbs;
    private bool tookDamage = false;

    [Header("SlimeStats")]
    public int health;
    



    private void Start()
    {

        jellyScript = GetComponent<UnityJellySprite>();

        float scaleRatio = health / 100;
        jellyScript.m_SpriteScale *= scaleRatio;
        jellyScript.Scale(scaleRatio, true);
        // Check to see if this object has multiple Rbs and gets them
        if (slimeStats.multipleRbs)
        {
            hasMultipleRbs = true;
            Debug.Log("HasMultipleRbs");
            jellyRef = GameObject.Find(this.gameObject.name +" Reference Points");
            Debug.Log(this.gameObject.name);
            rbs = jellyRef.GetComponentsInChildren<Rigidbody2D>();
          // mainRB = rbs[0].GetComponent<JellySpriteReferencePoint>().ParentJellySprite.GetComponent<Rigidbody2D>();

        } 
        // Else just use the standard Rigibody
        else
        {
            standardSlimeRb = GetComponent<Rigidbody2D>();
        }


        target1 = GameObject.Find("TargetGroup").GetComponent<CinemachineTargetGroup>();       // Adds the target group and caches it
        audioSource = GetComponent<AudioSource>();                                             // Adds the AudioSource on the slime 
        tank = GameObject.Find("Tank");                                                        // Adds the tank
        floor = GameObject.Find("pls_01");                                                     // Adds the Floor
        uiControl = GameObject.Find("GameSystem");                                             // Adds the UI



    }
    private void Update()
    {
        // If Slime chosen has multiple Rbs then call method that deals with multiple under Region MultipleRbSlime
        if (hasMultipleRbs)
        {
            CheckIfStopedMoving();
        }
        // If standard Slime with only 1 RB then call standard method
        else
        {
            CheckIfStopedMovingStandard();
        }
        //Puts the score to screen
        AddScore();

        // Removes the floor from the camera
        if(transform.position.y > 100)
        {
            Debug.Log("Remove Floor");
            target1.RemoveMember(floor.transform);
        }

        //Set scale based on health
        //Debug.Log(health / 100);
    

    }

    #region ScoringSystem
    private void AddScore()
    {
        if ((int)transform.position.x > score)
            score = (int)transform.position.x;
        UIManager.instance.UpdateScoreText(score);
    }
    #endregion

    #region KillSlime

    // Marks the sime as inactive when it has stopped moving
    // It also removes the slime from the target group and then Adds the Tank back into the Camera group
    // Could maybe remove this so it stays at slime location when end game UI pops up?
    private void KillSlime()
    {
       // target1.RemoveMember(this.transform);
        //target1.AddMember(tank.transform,1,0);
        
        //roundOverUI = uiControl.GetComponentInChildren<UIManager>();
        UIManager.instance.EnableRoundOverUI();
    }

    #endregion
    // If Slime has collided with a non player object such as bouncing pad then play sound
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!collision.gameObject.CompareTag("Player"))
    //    {
    //        if (collision.gameObject.CompareTag("BouncingPad"))
    //        {
    //            audioSource.PlayOneShot(slimeStats.slimeNoises[0]);
    //        }
    //        else
    //        {
                
    //            int randomNumber = 0;
    //            audioSource.PlayOneShot(slimeStats.slimeNoises[Random.RandomRange(1,slimeStats.slimeNoises.Length)]);
    //        }
    //    }
    //}

    public void PlaySound()
    {
        int randomNumber = 0;
        audioSource.PlayOneShot(slimeStats.slimeNoises[Random.RandomRange(1, slimeStats.slimeNoises.Length)]);
    }

    #region MultipleRbSlime
    //Checks to see if all Rbs on a slime has stopped moving and creates a flag and money.
    private void CheckIfStopedMoving()
    {
        
        

        if (health <=0)
        {
            hasStopedMoving = true;
            if (!hasSpawndFlag)
            {
                GameObject obj = Instantiate(flag, new Vector2(transform.position.x, flag.transform.position.y), flag.transform.rotation);
                hasSpawndFlag = true;
            }
            //target1.AddMember(obj.transform,1,0);

            // if score is over 100 add 100 money
            if (score > 100)
            {
                PlayerManager.money = 100;
            }
            this.gameObject.SetActive(false);
            Invoke("KillSlime", 5);
            hasStopedMoving = false;
        }
    }
    #endregion

    #region SlimeStandard

    // Standard Slime with no multiple RidigedBodies 
    private void CheckIfStopedMovingStandard()
    {

        // If RB is no longer moving then mark as stopped moving
        if(standardSlimeRb.IsSleeping() && !hasStopedMoving)
        {
            hasStopedMoving = true;
            if (!hasSpawndFlag)
            {
                // Create a flag to show where it has landed.
                GameObject obj = Instantiate(flag, new Vector2(transform.position.x, flag.transform.position.y), flag.transform.rotation);
                hasSpawndFlag = true;
            }

            // If Slime has gone over 100 along the X axies then add money
            if (score > 100)
            {
                PlayerManager.money = 100;
            }
            // Kill the slime in 5 seconds.
            Invoke("KillSlime", 5);
            hasStopedMoving = false ;
        }
    }

    #endregion


    public void TakeDamage(int damage)
    {
       

        if (!tookDamage)
        {
            foreach (Rigidbody2D rig in rbs)
            {
                rig.AddForce(Vector3.right * 2, ForceMode2D.Impulse);
                rig.AddForce(Vector3.up * 20, ForceMode2D.Impulse);
            }
            health -= damage;
            float scaleRatio = 0.9f;
            jellyScript.m_SpriteScale = new Vector2(health/100,health/100);
            jellyScript.Scale(scaleRatio, true);
            tookDamage = true;
            Invoke("ResetDamage", 1);
            
        }

    }

    private void ResetDamage()
    {
        tookDamage = false;
    }
}
