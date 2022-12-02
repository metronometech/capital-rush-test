using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class daily_reward_system : MonoBehaviour
{

    [SerializeField] GameObject rewards;
    [SerializeField] Slider slider;
    [SerializeField] Sprite checked_image;
    [SerializeField] Transform rays;
    [Space(10)]
    [Header("Only for debug")]
    [SerializeField] int day;
    [SerializeField] float speed, delay;

    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("daily_reward"))
            PlayerPrefs.SetInt("daily_reward", 0);
        else if (PlayerPrefs.GetInt("daily_reward") < 6)
            PlayerPrefs.SetInt("daily_reward", PlayerPrefs.GetInt("daily_reward") + 1);

        day = PlayerPrefs.GetInt("daily_reward");
        StartCoroutine("FillSlider");
        AwardActive();
    }
    void AwardActive()
    {
        for(int i =1; i <= day+1; i++)
        {
            Transform reward_child = rewards.transform.GetChild(i);
            reward_child.GetComponent<Image>().color = Color.white;
            Debug.Log("click" , reward_child);
            reward_child.GetChild(0).gameObject.GetComponent<Image>().sprite = checked_image;
        }
        rays.gameObject.SetActive(true);
        rays.SetParent(rewards.transform.GetChild(day+1));
        rays.localPosition = new Vector3(0.5f, 1f, rays.localPosition.z);
        rays.SetParent(rewards.transform);
        rays.transform.SetSiblingIndex(0);
    }

    IEnumerator FillSlider()
    {
        float TargetValue = (day < 6) ? (day*10) : (day*10 + 4);
        
        while ((int)TargetValue != (int)slider.value)
        {
            slider.value = Mathf.Lerp(slider.value, TargetValue+0.5f, speed);
            yield return new WaitForSeconds(delay);
        }

        StopCoroutine("FillSlider");

        yield return null;
    }
}
