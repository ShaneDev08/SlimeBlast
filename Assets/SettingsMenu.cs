using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public Button soundButton;
    public Sprite soundUnMute;
    public Sprite soundMute;
    public bool isMuted;
    public bool isConnectedToPlayServices;

    public void SoundControl()
    {
        //isMuted = !isMuted;
        if(isMuted)
        {
            soundButton.GetComponent<Image>().sprite = soundUnMute;
        } 
        else 
        {
            soundButton.GetComponent<Image>().sprite = soundMute;
        }

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartSignIn()
        {
            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce,(result)=>
            {
                switch(result)
                {
                    case SignInStatus.Success:
                    isConnectedToPlayServices = true;
                        SaveManager.instance.OpenSaveToCloud(false);
                    break;
                    default:
                    isConnectedToPlayServices = false;
                    break;
                }
            });

}
}