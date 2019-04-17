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
    [SerializeField]
    private int score_GO = 1;
    [SerializeField]
    private int chicks = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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


        if (chicks == 0)
        {
            text_Win.text = "You Win!";
            gameOverUI.gameObject.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;

        }
        if (score_GO == 0)
        {
            text_Win.text = "You Lose!";
            gameOverUI.gameObject.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
