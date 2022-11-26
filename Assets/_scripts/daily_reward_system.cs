using UnityEngine;

public class daily_reward_system : MonoBehaviour
{

    [SerializeField] GameObject rewards;

    public void claim()
    {

        if (!PlayerPrefs.HasKey("daily_reward")) 
            PlayerPrefs.SetInt("daily_reward",0);
        else
            PlayerPrefs.SetInt("daily_reward",PlayerPrefs.GetInt("daily_reward")+1);        
        
    }

    public void ads_bonus()
    {

    }

    void reward_active(int day_num)
    {
        
    }
}
