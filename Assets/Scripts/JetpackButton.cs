using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetpackButton : MonoBehaviour
{
    
    [SerializeField] private ObjectPool pool;
    public GameObject slimeSpawnd;
    private SlimeBall slimeBall;
    public bool isHolding = false;
    private bool hasSpawned;

    private void Start()
    {
        if(!PlayerManager.instance.CheckIfWorldUpgradeBought(1))
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (!hasSpawned)

        if(slimeBall = null)
        slimeBall = slimeSpawnd.GetComponent<SlimeBall>();
       
            if(isHolding)

        {

            slimeSpawnd = pool.GetCurrentActiveObject();

            if (slimeSpawnd != null)
            {
                hasSpawned = true;
            }
        }

        if (slimeSpawnd != null)
        {

            if (isHolding)
            {
                slimeSpawnd.GetComponent<SlimeBall>().JetPackForce();
            }
            else
            {
                slimeSpawnd.GetComponent<SlimeBall>().StopJetPacking();
            }


            if (slimeSpawnd.GetComponent<SlimeBall>().jetPackAmount <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }

    }


    public void UseJetPack()
    {
        isHolding = true;

      
    }

    public void NotHolding()
    {
        isHolding = false;
    }

    
}
