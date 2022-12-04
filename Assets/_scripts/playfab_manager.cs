using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

public class playfab_manager : MonoBehaviour
{
    public pie_manager pie_manager;
    public GameObject black_bg;
    [SerializeField] data_handler DataHandler;
    [SerializeField] daily_reward_system rewardSystem;
    void Start()
    {
        login();
    }

    void login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("login Successful");
        get_data();
        black_bg.SetActive(false);
        
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("error");
        Debug.Log(error.GenerateErrorReport());
    }


    public void data_update(string vals)
    {
        black_bg.SetActive(true);
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "vals",vals }
            }
        };
        Debug.Log("data sent");
        PlayFabClientAPI.UpdateUserData(request, OnDataUpdate, OnError);
        
    }
    void OnDataUpdate(UpdateUserDataResult result)
    {
        get_data();
    }


    public void get_data()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }

    void OnDataRecieved(GetUserDataResult result)
    {
        if (result.Data == null)
        {

            Debug.Log(5);
        }
        else if (result.Data.ContainsKey("vals"))
        {
            List<int> gold = JsonUtility.FromJson<data>(result.Data["vals"].Value).gold;
            List<int> silver = JsonUtility.FromJson<data>(result.Data["vals"].Value).silver;
            List<int> crypto = JsonUtility.FromJson<data>(result.Data["vals"].Value).crypto;
            List<int> stock = JsonUtility.FromJson<data>(result.Data["vals"].Value).stock;

            pie_manager.set_data(gold, silver, crypto, stock);
            DataHandler.UpdateValues(JsonUtility.FromJson<data>( result.Data["vals"].Value));
        }
        else
        {
            Debug.Log("error reciecving");
        }
        
        black_bg.SetActive(false);
    }
    
}


