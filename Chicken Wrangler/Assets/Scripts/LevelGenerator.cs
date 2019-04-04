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
    private bool isEnoughChk = false;
    private int chickenSpawn = 4;
    //private bool isChickenSpawn = false;
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
                else if (!isEnoughChk && UnityEngine.Random.value > 0.7f)
                {
                    for (int a = 0; a <= chickenSpawn; a++)
                    {
                        Vector3 pos = new Vector3(i - UnityEngine.Random.Range(0.0f, width) / 2.0f, 1.25f, j - UnityEngine.Random.Range(0.0f, height) / 2.0f);
                        Instantiate(chicken, pos, Quaternion.identity);
                        //chickenSpawn++;
                        if (a == 4)
                        {
                            isEnoughChk = true;
                        }
                    } 
                }
                else if (!isPlayerSpawn && isEnoughChk)
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
