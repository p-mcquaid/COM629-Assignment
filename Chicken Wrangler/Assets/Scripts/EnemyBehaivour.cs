using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBehaivour : MonoBehaviour {
    //Nav Mesh agent to manipulate the character on the Nav Mesh Surface
    private NavMeshAgent agent;
    //Player GB, to get the players position
    public GameObject player;
    public float dist_toPlayer = 4.0f;
    public Text text;
    public bool isClose = false;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        text = GameObject.FindGameObjectWithTag("UI").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //get the distance between the player and the chicken
        float dist = Vector3.Distance(transform.position, player.transform.position);
        // if distance to player is less than 4.0f, run away
        if (dist < dist_toPlayer)
        {

            Vector3 direction_toPlayer = transform.position - player.transform.position;
            text.gameObject.SetActive(true);
            isClose = true;
            Vector3 newPos = transform.position + direction_toPlayer;
            agent.SetDestination(newPos);
        }
        if (dist > dist_toPlayer)
        {
            text.gameObject.SetActive(false);
            isClose = false;
        }
    }
}
