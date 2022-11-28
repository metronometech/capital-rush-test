using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

public class playfab_manager : MonoBehaviour
{
    public pie_manager pie_manager;
    public GameObject black_bg;
    [SerializeField] data_handler DataHandler;
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
        Debug.Log("Successful");
        get_data();
        black_bg.SetActive(false);
        
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("error");
        Debug.Log(error.GenerateErrorReport());
    }


    public void data_update(int gold, int silver, int crypto, int stock)
    {
        black_bg.SetActive(true);
        //get_data();
        //gold += this.gold;
        //    silver += this.silver;
        //crypto += this.crypto;
        //stock += this.stock;
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "gold",gold.ToString()},
                {"silver",silver.ToString() },
                {"crypto",crypto.ToString() },
                {"stock",stock.ToString() }
            }
        };
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
            pie_manager.set_data(5,5,5,5);
            Debug.Log(5);
        }
        else if (result.Data.ContainsKey("gold") && result.Data.ContainsKey("silver") && result.Data.ContainsKey("crypto") && result.Data.ContainsKey("stock"))
        {

            pie_manager.set_data(int.Parse(result.Data["gold"].Value), int.Parse(result.Data["silver"].Value), int.Parse(result.Data["crypto"].Value), int.Parse(result.Data["stock"].Value));
            DataHandler.UpdateValues(int.Parse(result.Data["gold"].Value), int.Parse(result.Data["silver"].Value), int.Parse(result.Data["crypto"].Value), int.Parse(result.Data["stock"].Value));
            Debug.Log(result.Data["gold"].Value);
        }
        else
        {
            Debug.Log("error reciecving");
        }
        black_bg.SetActive(false);
    }
}


