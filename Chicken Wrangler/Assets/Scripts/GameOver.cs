using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{

    public AdditionalUI additionalUI;
    public GameObject gameOverUI;
    public GameObject player;
    public TextMeshProUGUI text_Win;
    public List<Material> playerMats = new List<Material>();
    public bool isGameOver = false;
    [SerializeField]
    private int score_GO;
    [SerializeField]
    private int chicks;

    // Start is called before the first frame update
    void Start()
    {
        // set the score and amt of chicks to one to prevent game over immediately
        if (score_GO == 0 || chicks == 0)
        {
            score_GO = 1;
            chicks = 1;
        }
        
        // set game over Ui to false initially 
        gameOverUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //  fill variables if empty
        if (additionalUI == null)
        {
            additionalUI = GameObject.Find("Add UI").GetComponent<AdditionalUI>();
           
        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        score_GO = additionalUI.score_int;
        chicks = player.GetComponent<PlayerController>().chickens.Count;

        // of all chickens caught, You win
        if (chicks == 0)
        {
            text_Win.text = "You Win!";
            gameOverUI.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;

        }
        // if score = 0, you lose
        if (score_GO == 0)
        {
            text_Win.text = "You Lose!";
            gameOverUI.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;

        }
    }

    public void Restart()
    {
        // Restart button to restart the level from Game over UI
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(1);
        Debug.Log("Chicks: " + chicks + " Score: " + score_GO);
        
    }
    //Exit to main menu 
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
