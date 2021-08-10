using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using UnityEngine.UI;

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

    public void OpenSaveToCloud(bool saving)
    {
        if(Social.localUser.authenticated)
        {
            isSaving = saving;
            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution(saveName,GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork,ConflictResolutionStrategy.UseLongestPlaytime,SaveGameOpen);
        }
    }

    private void SaveGameOpen(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        if(status==SavedGameRequestStatus.Success)
        {
            if(isSaving)
            {
                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(GetDataToStore());
                SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().Build();
                ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta,update,data,SaveUpdate);
            }
            else
            {
                ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta,ReadSave);
            }
        }
    }

    private void ReadSave(SavedGameRequestStatus status, byte[] data)
    {
        if(status == SavedGameRequestStatus.Success)
        {
            string saveData = System.Text.ASCIIEncoding.ASCII.GetString(data);
            LoadData(saveData);
        }
    }

    private void LoadData(string saveData)
    {
        string[] data = saveData.Split('|');
        debugText.text = data[0];
    }

    private void SaveUpdate(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        debugText.text = "Successfully Saved";
    }

    private string GetDataToStore()
    {
        string Data = PlayerManager.money.ToString();
        return Data;
    }
    

}
