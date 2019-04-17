using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.Audio;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public AudioSource AudioSource;
    public TextMeshProUGUI money;
    public int m_Money;
    private void Start()
    {
        m_Money = PlayerPrefs.GetInt("Money", 0);
        money.text = "Money: " + PlayerPrefs.GetInt("Money", m_Money);
    }
    public void PressButton()
    {
        ShowAds(); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void ShowAds()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.Log("Error in showing ad");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad was skipped");
                break;
            case ShowResult.Finished:
                Debug.Log("Ad was finished");
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 5);
                break;
            default:
                break;
        }
    }
}
