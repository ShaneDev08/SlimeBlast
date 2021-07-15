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

    // Start is called before the first frame update

    public void Start()
    {
        audio = GameObject.Find("SoundController").GetComponent<AudioSource>();
    }

    IEnumerator sceneTransition()
    {
        yield return new WaitForSeconds(transitionSpeed);
        SceneManager.LoadScene("CharacterSelection");
    }

    public void PlayGame(){

        StartCoroutine(sceneTransition());
    }

    public void OpenSettings(){
        SceneManager.LoadScene("Settings");
    }

    public void OpenCharacterCollection(){
        SceneManager.LoadScene("CharacterCollection");
    }

    public void PlayButtonClick()
    {
        audio.PlayOneShot(buttonNoise,volume);
    }


}
