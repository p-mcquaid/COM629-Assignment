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
    public bool isPlayerClose = false;
    public float dist = 0.0f;
    // Use this for initialization
    void Start () {
 
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

   

    // Update is called once per frame
    void FixedUpdate () {
        IsClose();
    }

    public void IsClose()
    {
        //get the distance between the player and the chicken
        dist = Vector3.Distance(transform.position, player.transform.position);

        // if distance to player is less than 4.0f, run away
        if (dist < dist_toPlayer)
        {

            Vector3 direction_toPlayer = transform.position - player.transform.position;
            isPlayerClose = true;
            Vector3 newPos = transform.position + direction_toPlayer;
            agent.SetDestination(newPos);
        }
        else if (dist >= dist_toPlayer)
        {
            Vector3 randDirection = Random.insideUnitSphere * 3;
            randDirection += this.transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randDirection, out hit, 3, 1);
            Vector3 finalPos = hit.position;
            agent.SetDestination(finalPos);
        }

        if (dist > dist_toPlayer)
        {
            isPlayerClose = false;
        }
    }
}
