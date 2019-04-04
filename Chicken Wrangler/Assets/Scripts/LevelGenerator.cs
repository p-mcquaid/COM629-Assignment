using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour {
    //How many walls up and across you want
    public int width = 10, height = 10;
    //Player object and Walls
    public GameObject wall, player, chicken;
    //Get instance of NavMesh Surface to update it
    public NavMeshSurface surface;

    //has the player already been spawned?
    private bool isPlayerSpawn = false;
    private bool isChickenSpawn = false;
	// Use this for initialization
	void Start () {
        //Call Level Gen Method
        GenLevel();
        //Update nav Mesh
        surface.BuildNavMesh();
	}

    private void GenLevel()
    {
        // Loop for level
        for (int i = 0; i <= width; i+=2)
        {
            for (int j = 0; j <= height; j+=2)
            {
                //Random Wall Placement
                if (UnityEngine.Random.value > 0.7f)
                {
                    //Detirmine Wall Pos and place it
                    Vector3 pos = new Vector3(i - width / 2.0f, 1.0f, j - height / 2.0f);
                    Instantiate(wall, pos, Quaternion.identity, transform);
                }
                else if (!isChickenSpawn)
                {
                    Vector3 pos = new Vector3(i - width / 2.0f, 1.25f, j - height / 2.0f);
                    Instantiate(chicken, pos, Quaternion.identity);
                    isChickenSpawn = true;
                    Debug.Log(isPlayerSpawn);
                }
                else if (!isPlayerSpawn)
                {
                    Vector3 pos = new Vector3(i - width / 2.0f, 1.25f, j - height / 2.0f);
                    Instantiate(player, pos, Quaternion.identity);
                    isPlayerSpawn = true;
                    Debug.Log(isPlayerSpawn);
                }
                
            }
        }
    }
}
