using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

public class playfab_manager : MonoBehaviour
{
    public pie_manager pie_manager;
    public GameObject black_bg;
    int gold, silver, crypto, stock;
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
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("error");
        Debug.Log(error.GenerateErrorReport());
    }


    public void data_update(int gold, int silver, int crypto, int stock)
    {
        black_bg.SetActive(true);
        get_data();
        gold += this.gold;
            silver += this.silver;
        crypto += this.crypto;
        stock += this.stock;
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
        PlayFabClientAPI.UpdateUserData(request, null, OnError);

    }

    public void get_data()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }

    void OnDataRecieved(GetUserDataResult result)
    {
        if (result.Data == null)
        {
            pie_manager.set_data("5", "5", "5", "5");
            Debug.Log(5);
        }
        else if (result.Data.ContainsKey("gold") && result.Data.ContainsKey("silver") && result.Data.ContainsKey("crypto") && result.Data.ContainsKey("stock"))
        {
            gold = int.Parse(result.Data["gold"].Value);
            silver = int.Parse(result.Data["silver"].Value);
            crypto = int.Parse(result.Data["crypto"].Value);
            stock = int.Parse(result.Data["stock"].Value);

            pie_manager.set_data(result.Data["gold"].Value, result.Data["silver"].Value, result.Data["crypto"].Value, result.Data["stock"].Value);
            Debug.Log(result.Data["gold"].Value);
        }
        else
        {
            Debug.Log("error reciecving");
        }
        black_bg.SetActive(false);
    }
}


