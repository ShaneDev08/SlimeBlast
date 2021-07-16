using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private Button playGame;
    private Button settings;
    private Button characterSelection;
    private AudioSource audio;
    public AudioClip buttonNoise;
    private float transitionSpeed =1f;
    private float volume =0.5f;

    [Header("Tween Objects")]
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject slimeCollectionButton;
    [SerializeField] private GameObject aboutButton;
    [SerializeField] private GameObject scoreButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private float tweenTime = 1f;

    // Start is called before the first frame update

    public void Start()
    {
        audio = GameObject.Find("SoundController").GetComponent<AudioSource>();
    }

    IEnumerator sceneTransition()
    {
        yield return new WaitForSeconds(transitionSpeed);
        
    }

    public void PlayGame(){
         LeanTween.scale(playButton, Vector3.one * 2, tweenTime).setEasePunch();
         PlayButtonClick();
         StartCoroutine(sceneTransition());
         SceneManager.LoadScene("CharacterSelection");
    }

    public void OpenSettings(){
        LeanTween.scale(settingsButton, Vector3.one * 2, tweenTime).setEasePunch();
        PlayButtonClick();
        StartCoroutine(sceneTransition());
        SceneManager.LoadScene("Settings");
    }

    public void OpenCharacterCollection(){
        LeanTween.scale(slimeCollectionButton, Vector3.one * 2, tweenTime).setEasePunch();
        PlayButtonClick();
        StartCoroutine(sceneTransition());
        SceneManager.LoadScene("CharacterCollection");
    }

    public void OpenScore(){
        LeanTween.scale(scoreButton, Vector3.one * 2, tweenTime).setEasePunch();
        PlayButtonClick();
        StartCoroutine(sceneTransition());
        print("Hello");
    }

    public void OpenAbout(){
        LeanTween.scale(aboutButton, Vector3.one * 2, tweenTime).setEasePunch();
        PlayButtonClick();
        StartCoroutine(sceneTransition());
        print("Hello");
    }

    public void PlayButtonClick()
    {
        audio.PlayOneShot(buttonNoise,volume);
    }


}
