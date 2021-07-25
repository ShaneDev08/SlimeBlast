using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStarController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void startAnim()
    {
        LeanTween.scale(this, vector3.one, 0.5f).easeInPunch();
    }

}
