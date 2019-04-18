using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdditionalUI : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI amt_Chickens;
    public PlayerController playerController;

    public float timer;
    public int score_int;
   
    // Start is called before the first frame update
    private void Start()
    {
        //set inital values for timer, score and print score to the text object
        timer = 0f;
        score_int = 1000;
        score.text = score_int.ToString();

       
    }

    
    // Update is called once per frame
    void Update()
    {
        //if Pc is empty, fidn the correct instance in the scene
        if (playerController == null)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        // time until last refresh
        timer += Time.deltaTime;
        AddScore();
        amt_Chickens.text = SetChickens().ToString();
    }

    public void AddScore()
    {
        //if timer = 5, subtract 100 frin score and print it, reset timer
        if (timer > 5)
        {
            Debug.Log("timer"  + timer);

            score_int -= 100;

            score.text = score_int.ToString();

            timer = 0;
        }
    }

    public int SetChickens()
    {
        //Get the amount of chickens on screen, should always start with 5, returns the amount
        int amt_Chicks = 1;
        if (playerController != null)
        {
             amt_Chicks = playerController.chickens.Count; 
        }

        return amt_Chicks;
    }

}
