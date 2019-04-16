using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public AdditionalUI additionalUI;
    public PlayerController playerController;
    [SerializeField]
    private int score_GO = 1;
    [SerializeField]
    private int chicks = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (additionalUI == null)
        {
            additionalUI = GameObject.Find("Add UI").GetComponent<AdditionalUI>();
           
        }
        if (playerController == null)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        score_GO = additionalUI.score_int;
        chicks = playerController.chickens.Count;


        if (chicks == 0 || score_GO == 0)
        {
            
        }
    }
}
