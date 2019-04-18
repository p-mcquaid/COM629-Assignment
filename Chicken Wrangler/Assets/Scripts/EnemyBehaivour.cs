using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBehaivour : MonoBehaviour {
    //Nav Mesh agent to manipulate the character on the Nav Mesh Surface
    public NavMeshAgent agent;
    //Player GB, to get the players position
    public GameObject player;
    public float dist_toPlayer = 4.0f;
    public bool isPlayerClose = false;
    public bool isFreeze = false;
    public float dist = 0.0f;
    public GameObject child;
    [SerializeField]
    Material[] materialsArray;
    Material material;

    
    public Texture caughtTexture;


    // Use this for initialization
    void Start () {
        
        //set inital values for agent, player and get the chicken body GO from each chicken in the scene
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        foreach (Transform comp in transform)
        {
            if (comp.name == "ChickenBody")
            {
                child = comp.gameObject;
            }

        }
    }

   

    // Update is called once per frame
    void FixedUpdate () {
        IsClose();
        
    }

    public void Caught()
    {
        //children.Add(GetComponentInChildren<GameObject>());
        //change colour of chicken after being caught
        child.GetComponent<Renderer>().material.mainTexture = caughtTexture;
       
    }

    public void IsClose()
    {
        //code for when the chickens move about on their own
        
        //if they don't have to be still
        if (!isFreeze)
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
            // else walk around the scene
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
                //set player close to false when not close
                isPlayerClose = false;
            }
        }
    }
}
