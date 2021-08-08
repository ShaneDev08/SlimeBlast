using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GPSAuthentication : MonoBehaviour
{

    public static PlayGamesPlatform platform;  // Needs to be static so it does not create others
    public bool isConnectedToPlayServices;
    
       private void Start() 
       {
          InitializePGS();
       }
       public  void InitializePGS()
        {
            if(platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames()
            .Build();   // Might have to do enableSavedGames
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;

            platform = PlayGamesPlatform.Activate();
            StartSignIn();
        }
        
        }

        void StartSignIn()
        {
            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce,(result)=>
            {
                switch(result)
                {
                    case SignInStatus.Success:
                    isConnectedToPlayServices = true;
                    break;
                    default:
                    isConnectedToPlayServices = false;
                    break;
                }
            });
        
        }
    }

