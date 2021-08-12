using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyUpgradesCannon : MonoBehaviour
{
    public static BuyUpgradesCannon instance;

    private float tweenTime = 0.5f;
    private int cannonId;

    private static CannonListSo cannonList;

    private List<GameObject> stars = new List<GameObject>();
    private List<GameObject> newStars = new List<GameObject>();

    private Color fullColor;
    private Color fadedColor;


    [Header("UI")]
    [SerializeField] private CanvasGroup upgradeBox;
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] GameObject star;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI upgradeValueText;

    // Update is called once per frame
    private void OnEnable() 
    {
        upgradeBox.LeanAlpha(1,tweenTime);
        cannonList = Instantiate(Resources.Load("ListOfCannons", typeof(CannonListSo)) as CannonListSo);
        StarColors();

    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        moneyText.text = "SlimeCoins: " + Mathf.Round(PlayerManager.money).ToString();
        upgradeValueText.text = Mathf.Round(cannonList.listOfCannons[cannonId].powerUpgrade.upgradeValue).ToString();
    }

    public void CloseUpgradeScreen()
    {
        upgradeBox.LeanAlpha(0,tweenTime);
        Invoke("Deactivate",1);
        for (int i = 0; i < stars.Count; i++)
        {
            Destroy(stars[i]);
        }
        stars.Clear();
        newStars.Clear();
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    public void CreateStars()
    {
        for (int i = 0; i < cannonList.listOfCannons[cannonId].powerUpgrade.upgradeAmount; i++)
        {

            GameObject instance = Instantiate(star);
            Vector3 scale = instance.transform.localScale;
            instance.transform.SetParent(grid.gameObject.transform);
            instance.transform.localScale = scale;
            stars.Add(instance);
            
        }

        foreach (GameObject starr in stars)
        {
            if (starr == stars[0])
            {
                //return;
            }
            else
            {
                starr.GetComponent<Button>().enabled = false;
                starr.GetComponentInChildren<Image>().color = fadedColor;
            }
        }

        newStars = new List<GameObject>(stars);
        CheckForStarsBought();

    }


    public void RemoveButton()
    {
        if (cannonList.listOfCannons[cannonId].powerUpgrade.CanBuy())
        {
            
            cannonList.listOfCannons[cannonId].powerUpgrade.BuyUpgrade();
            newStars.Remove(newStars[0]);

            // If more stars are still available, enable the button on the next star 
            if (newStars.Count > 0)
            {
                newStars[0].GetComponent<Button>().enabled = true;
                newStars[0].GetComponent<Image>().color = fullColor;
            }
        }
    }

    private void CheckForStarsBought()
    {
        // Loop through each upgrade and generate a new list
            // if the current upgrade is greater then 0 then an upgrade has been bought
            if (cannonList.listOfCannons[cannonId].powerUpgrade.currentUpgrade > 0)
            {

                for (int i = 0; i < cannonList.listOfCannons[cannonId].powerUpgrade.currentUpgrade; i++)
                {

                // Get the 0 element of the list and make the button false so cannot click on it and then remove from the list. Do this for each upgrade bought  so if 2 stars have been bought then loop through twice and remove the first 2 from the list and disable their buttons
                newStars[0].GetComponent<Button>().enabled = false;
                newStars[0].GetComponent<Image>().color = fullColor;
                newStars.Remove(newStars[0]);
                }

                // Once the bought upgrades have finished if the list is greater then 0 then get the first avaiable star and set it to be enabled.
                if (newStars.Count > 0)
                {
                newStars[0].GetComponent<Button>().enabled = true;
                newStars[0].GetComponent<Image>().color = fullColor;
                }


            }

    }

    private void StarColors()
    {
        fullColor = star.GetComponent<Image>().color;
        fullColor.a = 1;
        fadedColor = fullColor;
        fadedColor.a = 0.2f;
    }

    public void SetCannonID(int id)
    {
        cannonId = id;
    }


}
