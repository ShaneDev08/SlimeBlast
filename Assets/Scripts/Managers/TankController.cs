using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private Touch touch;
    [SerializeField] private Transform cannonObject;
    private Vector2 startPos;
    Quaternion rotationZ;
    float rotateSpeed = 0.1f;
    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            
                touch = Input.GetTouch(0);

                if(touch.position.y < Screen.height /2)
                {
                    if(touch.phase == TouchPhase.Moved)
                    {
                        cannonObject.transform.Rotate(0f, 0f, -touch.deltaPosition.y * rotateSpeed);
                    }
                }
                
            

        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            cannonObject.transform.Rotate(0, 0, -1 * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.UpArrow))
        {
            cannonObject.transform.Rotate(0, 0, 1 * Time.deltaTime);
        }
    }
}

