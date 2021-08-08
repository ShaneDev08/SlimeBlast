using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIControllerUnlocks : MonoBehaviour
{
    // Start is called before the first frame update
private static UnlockObjectList unlockList;
[SerializeField]
private GameObject unlockTemplate;
[SerializeField]
private HorizontalLayoutGroup unlockHolder;


private void Start() 
{
    unlockList = Instantiate(Resources.Load("UnlockList", typeof(UnlockObjectList)) as UnlockObjectList);
    AddUnlocks();
}



public void AddUnlocks()
{
    for (int i = 0; i < unlockList.unlockList.Count; i++)
    {
        GameObject template = Instantiate(unlockTemplate);
        template.transform.SetParent(unlockHolder.gameObject.transform);
        //unlockList.unlockList[i].slimeID;
        template.gameObject.transform.Find("CharacterName").GetComponent<TextMeshProUGUI>().text =  unlockList.unlockList[i].slimeName.ToString();
        //unlockList.unlockList[i].isUnlocked;
        template.gameObject.transform.Find("CharacterValue").GetComponent<TextMeshProUGUI>().text = unlockList.unlockList[i].slimeUnlockValue.ToString();
    }
    
}

public void OnClickMainMenu()
{
    SceneManager.LoadScene("MainMenu");
}

}
