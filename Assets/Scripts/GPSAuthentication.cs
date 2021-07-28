using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GPSAuthentication : MonoBehaviour
{
    public static PlayGamesPlatform platform;  // Needs to be static so it does not create others

    private void Start()
    {
        if(platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();   // Might have to do enableSavedGames
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;

            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate(success =>
            {
                if (success)
                {
                    Debug.Log("Logged in Successfully!");
                }
                else
                {
                    Debug.Log("Login Failed");
                }


            }
            );
    }
}
