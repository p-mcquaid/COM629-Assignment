using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pause_UI;

    // Update is called once per frame
    void Update()
    {
        //if user presses escape or back on mobile, show pause menu or close it if it is already up
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        //pause game, show UI
        pause_UI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        // Unpause Game and hide UI
        pause_UI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void LoadMenu()
    {
        // Quit the game and set Time to normal
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }
}
