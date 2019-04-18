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
    private int playAd = 0;
    private void Start()
    {
        // code to try and prevent ads showing every time, doesn't work
        PlayerPrefs.SetInt("PlayAd", playAd);
        // get the players money and print it 
        m_Money = PlayerPrefs.GetInt("Money", 0);
        money.text = "Money: " + PlayerPrefs.GetInt("Money", m_Money);
    }
    public void PressButton()
    {
        // Play the game and show an ad
        ShowAds(); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void ShowAds()
    {

        if (playAd == 0)
        {
            if (Advertisement.IsReady("rewardedVideo"))
            {
                var options = new ShowOptions { resultCallback = HandleShowResult };
                Advertisement.Show("rewardedVideo", options);
                PlayerPrefs.SetInt("PlayAd", 1);
            } 
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
