using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStarController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject starImage;

    public void startAnim()
    {
        LeanTween.scale(starImage, Vector3.one, 0.5f).setEasePunch();
        
    }

}
