using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [Header("Cannon Objects")]
    [SerializeField] private Transform cannonBarrel;

    [Header("Cannon Stats")]
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;

    private bool direction = true;
    public bool isShooting = false;

    public static TankController instance;

    private void Start()
    {
        instance = this;
    }


    void Update()
    {
        if (!isShooting)
        {
            if (direction)
            {
                cannonBarrel.Rotate(0, 0, rotateSpeed * Time.deltaTime, Space.Self);
                if (cannonBarrel.transform.localEulerAngles.z > maxHeight)
                {
                    direction = false;
                }
            }

            else if (!direction)
            {
                
                cannonBarrel.Rotate(0, 0, -rotateSpeed * Time.deltaTime, Space.Self);
                if (cannonBarrel.transform.localEulerAngles.z < minHeight || cannonBarrel.transform.localEulerAngles.z > maxHeight)
                {
                    direction = true;
                }
            }
        }


    }
}

