using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SlimeSelectorController : MonoBehaviour
{
    private int selectedCharacterIndex;
    [SerializeField] private float transitionSpeed = 3f;
    private Color desiredColour;
    [Header("Character List")]
    [SerializeField] private List<CharacterSelection> characterSelection = new List<CharacterSelection>();
    [SerializeField] private List<GameObject> healthStars = new List<GameObject>();
    [SerializeField] private List<GameObject> bouncinessStars = new List<GameObject>();
    [SerializeField] private List<GameObject> weightStars = new List<GameObject>();

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private Image characterSplash;
    [SerializeField] private Image backgroundColour;
    [SerializeField] private GridLayoutGroup[] statGrids;
    [SerializeField] GameObject statStar;

    [Header("Sounds")]
    [SerializeField] private AudioClip buttonNoise;
    [SerializeField] private AudioClip characterNoise;
    [SerializeField] public float audioVolume = 0.5F;
    private AudioSource audio;
    [Header("Tween Objects")]
    [SerializeField] private GameObject blastButton;
    [SerializeField] private GameObject leftSelection;
    [SerializeField] private GameObject rightSelection;
    [SerializeField] private GameObject homeButton;
    [SerializeField] private float tweenTime = 1f;

    private void Start() {
        UpdateCharacterSelectionUI();
        audio = GameObject.Find("CharacterSelectionController").GetComponent<AudioSource>();
    }


    private void UpdateCharacterSelectionUI(){
        //Character Image Change, Name, Background Colour
        characterSplash.sprite =  characterSelection[selectedCharacterIndex].characterSplashImage;
        characterName.text =  characterSelection[selectedCharacterIndex].characterName;
        desiredColour =  characterSelection[selectedCharacterIndex].characterBackgroundColour;
        PlayerManager.instance.slimeBall = characterSelection[selectedCharacterIndex].slime;
        AddStars();
    }

    public void changeCharacterLeft(){
        LeanTween.scale(leftSelection, Vector3.one * 2, tweenTime).setEasePunch();
        audio.PlayOneShot(buttonNoise, audioVolume);
        selectedCharacterIndex--;
        if(selectedCharacterIndex < 0)
            selectedCharacterIndex = characterSelection.Count -1;
            UpdateCharacterSelectionUI();
    }
    
    public void changeCharacterRight(){
        LeanTween.scale(rightSelection, Vector3.one * 2, tweenTime).setEasePunch();
        audio.PlayOneShot(buttonNoise, audioVolume);
        selectedCharacterIndex++;
        if(selectedCharacterIndex == characterSelection.Count)
            selectedCharacterIndex = 0;
            UpdateCharacterSelectionUI();
    }

    public void ChangeSceneToGame()
    {
        LeanTween.scale(blastButton, Vector3.one * 2, tweenTime).setEasePunch();
        audio.PlayOneShot(buttonNoise, audioVolume);
        StartCoroutine(sceneTransition());
        SceneManager.LoadScene("DevScene 1");
        
    }

    IEnumerator sceneTransition(){
        ;
        yield return new WaitForSeconds(transitionSpeed);
    }

     public void ChangeSceneToMainMenu()
    {
        LeanTween.scale(homeButton, Vector3.one * 2, tweenTime).setEasePunch();
        audio.PlayOneShot(buttonNoise, audioVolume);
        StartCoroutine(sceneTransition());
        SceneManager.LoadScene("MainMenu");
    }

    public void AddStars()
    {
        ClearStars();
        SlimeBall stats = characterSelection[selectedCharacterIndex].slime.GetComponent<SlimeBall>();
        int count = CalculateHealth(stats);
        for (int i = 0; i < count; i++)
        {
            GameObject instance = Instantiate(statStar);
            instance.transform.SetParent(statGrids[0].gameObject.transform);
            healthStars.Add(instance);
        }
        count = CalculateBounciness(stats);
        for (int i = 0; i < count; i++)
        {
            GameObject instance = Instantiate(statStar);
            instance.transform.SetParent(statGrids[1].gameObject.transform);
            bouncinessStars.Add(instance);
        }
        count = CalculateWeight(stats);
        for (int i = 0; i < count; i++)
        {
            GameObject instance = Instantiate(statStar);
            instance.transform.SetParent(statGrids[2].gameObject.transform);
            weightStars.Add(instance);
        }
        
    }

    private void ClearStars()
    {
        if (healthStars.Count > 0)
        {
            for (int i = 0; i < healthStars.Count; i++)
            {
                Destroy(healthStars[i]);
            }
            healthStars.Clear();
        }
        if (bouncinessStars.Count > 0)
        {
            for (int i = 0; i < bouncinessStars.Count; i++)
            {
                Destroy(bouncinessStars[i]);
            }
            bouncinessStars.Clear();
        }
        if (weightStars.Count > 0)
        {
            for (int i = 0; i < weightStars.Count; i++)
            {
                Destroy(weightStars[i]);
            }
            weightStars.Clear();
        }
    }

    private int CalculateHealth(SlimeBall stats)
    {
        int count = 0;
        if(stats.slimeStats.slimeHealth <= 100)
        {
            count = 1;
        }
        else if (stats.slimeStats.slimeHealth > 100 && stats.slimeStats.slimeHealth <= 200 )
        {
            count = 2;
        }
        else if (stats.slimeStats.slimeHealth > 200 && stats.slimeStats.slimeHealth <= 300 )
        {
            count = 3;
        }
        else if (stats.slimeStats.slimeHealth > 300 && stats.slimeStats.slimeHealth <= 400 )
        {
            count = 4;
        }
        else if (stats.slimeStats.slimeHealth > 400 && stats.slimeStats.slimeHealth <= 500 )
        {
            count = 5;
        }
        return count;
    }

    private int CalculateBounciness(SlimeBall stats)
    {
        int count = 0;
        if(stats.slimeStats.slimeBounciness <= 100)
        {
            count = 1;
        }
        else if (stats.slimeStats.slimeBounciness > 100 && stats.slimeStats.slimeBounciness <= 200 )
        {
            count = 2;
        }
        else if (stats.slimeStats.slimeBounciness > 200 && stats.slimeStats.slimeBounciness <= 300 )
        {
            count = 3;
        }
        else if (stats.slimeStats.slimeBounciness > 300 && stats.slimeStats.slimeBounciness <= 400 )
        {
            count = 4;
        }
        else if (stats.slimeStats.slimeBounciness > 400 && stats.slimeStats.slimeBounciness <= 500 )
        {
            count = 5;
        }
        return count;
    }

    private int CalculateWeight(SlimeBall stats)
    {
        int count = 0;
        if(stats.slimeStats.slimeWeight <= 100)
        {
            count = 1;
        }
        else if (stats.slimeStats.slimeWeight > 100 && stats.slimeStats.slimeWeight <= 200 )
        {
            count = 2;
        }
        else if (stats.slimeStats.slimeWeight > 200 && stats.slimeStats.slimeWeight <= 300 )
        {
            count = 3;
        }
        else if (stats.slimeStats.slimeWeight > 300 && stats.slimeStats.slimeWeight <= 400 )
        {
            count = 4;
        }
        else if (stats.slimeStats.slimeWeight > 400 && stats.slimeStats.slimeWeight <= 500 )
        {
            count = 5;
        }
        return count;
    }
    
    [System.Serializable]
    public class CharacterSelection{
        public Sprite characterSplashImage;
        public string characterName;
        public Color characterBackgroundColour;
        public GameObject slime;
    }
}
