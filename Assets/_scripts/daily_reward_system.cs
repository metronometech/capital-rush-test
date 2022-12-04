using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class daily_reward_system : MonoBehaviour
{

    [SerializeField] GameObject rewards;
    [SerializeField] Slider slider;
    [SerializeField] Sprite checkedImage;
    [Space(10)]
    [Header("Only for debug")]
    int lastDay = 0;
    [SerializeField] float speed, delay;
    string lastDate;

    private void Start()
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

    public void get_data()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }

    void OnDataRecieved(GetUserDataResult result)
    {
        if (result.Data.ContainsKey("date") && result.Data.ContainsKey("dailyRewardDay"))
        {
            lastDate = result.Data["date"].Value+1;
            lastDay = int.Parse(result.Data["dailyRewardDay"].Value);
        }
        DateAndTime();

    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("login Successful");
        get_data();
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("error");
        Debug.Log(error.GenerateErrorReport());
    }

    public void DateAndTime()
    {
        PlayFabClientAPI.GetTime(new GetTimeRequest(), GotTime, FailedToGetTIme);
    }

    void AwardActive()
    {

        for (int i = 0; i <= lastDay; i++)
        {
            Transform reward_child = rewards.transform.GetChild(i);
            reward_child.GetComponent<Image>().color = Color.white;

        }
        Transform rays = rewards.transform.GetChild(lastDay).GetChild(2);
        rays.gameObject.SetActive(true);
        rays.SetParent(rewards.transform.parent);
        rays.SetSiblingIndex(0);
    }

    IEnumerator FillSlider()
    {
        float TargetValue = (lastDay < 6) ? (lastDay * 10) : (lastDay * 10 + 4);
        int dayTick = 0;

        if (TargetValue == 0) rewards.transform.GetChild(dayTick).GetChild(0).gameObject.GetComponent<Image>().sprite = checkedImage;

        while ((int)TargetValue != (int)slider.value)
        {
            slider.value = Mathf.Lerp(slider.value, TargetValue + 0.5f, speed);
            if (slider.value / 10 >= dayTick)
            {
                rewards.transform.GetChild(dayTick).GetChild(0).gameObject.GetComponent<Image>().sprite = checkedImage;
                dayTick++;
                Debug.Log("tick");
            }
            yield return new WaitForSeconds(delay);
        }

        StopCoroutine("FillSlider");

        yield return null;
    }

    void GotTime(GetTimeResult currentTime)
    {

        if (lastDay == 0 || currentTime.Time.Date >= System.DateTime.Parse( lastDate).Date.AddDays(lastDay))
        {
            Debug.Log(currentTime.Time.ToString());
            var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
            {
                { "date",currentTime.Time.ToString() },
                {"dailyRewardDay" , lastDay.ToString()}
            }
            };
            Debug.Log("diione");
            PlayFabClientAPI.UpdateUserData(request, null, OnError);
        }

        StartCoroutine("FillSlider");
        AwardActive();



    }
    void FailedToGetTIme(PlayFabError error)
    {
        Debug.Log("error" + error.GenerateErrorReport());
    }


}
