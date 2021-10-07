using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.UI;
using System;

public class SaveManager : MonoBehaviour
{

    [SerializeField]
    private bool isSaving = false;
    private string saveName = "SlimeBlastSave";
    private Text debugText;

    public static SaveManager instance;
    //Cloud Saving

     private void Awake() {
        instance=this;
    }

    private void Start()
    {
        //Debug.Log("Loading Save on Start Game");
        //OpenSave(false);
    }

    //public void OpenSaveToCloud(bool saving)
    //{
    //    if(Social.localUser.authenticated)
    //    {
    //        isSaving = saving;
    //        ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution(saveName,GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork,ConflictResolutionStrategy.UseLongestPlaytime,SaveGameOpen);
    //    }
    //}

    //private void SaveGameOpen(SavedGameRequestStatus status, ISavedGameMetadata meta)
    //{
    //    if(status==SavedGameRequestStatus.Success)
    //    {
    //        if(isSaving)
    //        {
    //            Debug.Log("Saving Game Now PLEASE READ");
    //            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(GetDataToStore());
    //            SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().Build();
    //            Debug.Log(meta);
    //            Debug.Log(data.ToString());
    //            ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta,update,data,SaveUpdate);
    //        }
    //        else
    //        {
    //            Debug.Log("Loading GOOGLE PLAY SAVE");
    //            ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta,ReadSave);
    //        }
    //    }
    //}

    //private void ReadSave(SavedGameRequestStatus status, byte[] data)
    //{
    //    if(status == SavedGameRequestStatus.Success)
    //    {
    //        string saveData = System.Text.ASCIIEncoding.ASCII.GetString(data);
    //        LoadData(saveData);
    //    }
    //}

    //private void LoadData(string saveData)
    //{
    //    Debug.Log("Loading Player Money");
    //    PlayerManager.money = int.Parse(saveData);
    //}

    //private void SaveUpdate(SavedGameRequestStatus status, ISavedGameMetadata meta)
    //{
    //    debugText.text = "Successfully Saved";
    //}

    //private string GetDataToStore()
    //{
    //    string Data = PlayerManager.money.ToString();
    //    Debug.Log("Saving Player Money");
    //    return Data;
    //}



    private string GetSaveString()
    {
        return PlayerManager.money.ToString();
    }


    
    public void OpenSave(bool saving)
    {
        if(Social.localUser.authenticated)
        {
            isSaving = saving;
            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution("RunningSlime",
                GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork,
                ConflictResolutionStrategy.UseLongestPlaytime, SaveGameOpened);
        }
    }

    private void SaveGameOpened(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        Debug.Log("SavedGameOpened");
       if(status==SavedGameRequestStatus.Success)
        {
            if(isSaving) // Writing
            {
                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(GetSaveString());
                SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().WithUpdatedDescription("Saved at " + DateTime.Now.ToString()).Build();


                ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, update, data, SaveUpdate);
            }
            else  // Loading
            {
                ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, SaveRead);
            }
        }
    }

    private void SaveRead(SavedGameRequestStatus status, byte[] data)
    {
       if(status == SavedGameRequestStatus.Success)
        {
            string savedData = System.Text.ASCIIEncoding.ASCII.GetString(data);
            Debug.Log(savedData);

            PlayerManager.money = int.Parse(savedData);
        }
    }

    private void SaveUpdate(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        Debug.Log(status);
    }
}
