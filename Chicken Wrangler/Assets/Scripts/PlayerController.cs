﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent;
    public List<GameObject> chickens = new List<GameObject>();
    public Image lasso_img;
    public Image power_Bar;
    public Image power_Goal;
    public Image power_Goal_Range;
    public Image power_BG;
    public int sign = 1;
    public bool isLasso = false;

    [SerializeField]
    private Touch touch;
    [SerializeField]
    private float chicken_Range = 4.0f;
    [SerializeField]
    private float[] dist = new float[5];
    [SerializeField]
    private Vector3 store_Dest;
    [SerializeField]
    private float percentage;
    [SerializeField]
    private float currentFill;
    [SerializeField]
    private float closest_Chick = 100f;
    [SerializeField]
    private GameObject near_Chicken = null;
    [SerializeField]
    private bool isChick_close = false;
    [SerializeField]
    private GameObject[] g = new GameObject[5];



    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("Camera").GetComponent<Camera>();

        for (int i = 0; i < g.Length; i++)
        {
            g = GameObject.FindGameObjectsWithTag("Chicken");
        }
        foreach (GameObject c in g)
        {
            chickens.Add(c);

        }

        for (int i = 0; i < dist.Length; i++)
        {
            dist[i] = 0.0f;
        }

        lasso_img = GameObject.Find("Lasso").GetComponent<Image>();
        lasso_img.gameObject.SetActive(false);

        power_Bar = GameObject.Find("power_bar").GetComponent<Image>();
        power_Goal = GameObject.Find("power_Goal").GetComponent<Image>();
        power_Goal_Range = GameObject.Find("power_Goal_Range").GetComponent<Image>();
        power_BG = GameObject.Find("power_BG").GetComponent<Image>();

        if (power_Bar != null && power_Goal != null)
        {
            //percentage = power_Bar.fillAmount * 100;
            power_Goal.fillAmount = Random.Range(0.0f, 1.0f);
            power_Goal_Range.fillAmount = power_Goal.fillAmount + 0.1f;
            
        }
        power_Bar.gameObject.SetActive(false);
        power_Goal.gameObject.SetActive(false);
        power_Goal_Range.gameObject.SetActive(false);
        power_BG.gameObject.SetActive(false);

    }
    void FixedUpdate()
    {
        GetChickenDist();


        #region Movement Controls
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            Ray ray = cam.ScreenPointToRay(touch.position);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        #endregion


    }

    public void GetChickenDist()
    {
        // get the closest chicken for comparison purposes
        while (sign != -2)
        {
            for (int i = 0; i < chickens.Count; i++)
            {
                float close = Vector3.Distance(chickens[i].transform.position, this.transform.position);

                if (close < closest_Chick)
                {
                    near_Chicken = chickens[i];
                }
            }
            
        }
            
        

        // get chicken Distances
        for (int i = 0; i < chickens.Count; i++)
        {
            dist[i] = Vector3.Distance(chickens[i].transform.position, this.transform.position);



            if (dist[i] <= chicken_Range)
            {
                isChick_close = true;
                
                
                // if player is close enough and presses space
                if (Input.GetKey(KeyCode.Space))
                {

                    //freezes positions 
                    for (int j = 0; j < chickens.Count; j++)
                    {
                        chickens[j].GetComponent<EnemyBehaivour>().agent.SetDestination(chickens[j].transform.position);
                        chickens[j].GetComponent<EnemyBehaivour>().enabled = false;

                    }
                    // store players postion and stops them from moving by setting dest to where they are
                    store_Dest = agent.destination;
                    this.agent.SetDestination(this.transform.position);
                    //activates power bar
                    power_Bar.gameObject.SetActive(true);
                    power_Goal.gameObject.SetActive(true);
                    power_Goal_Range.gameObject.SetActive(true);
                    power_BG.gameObject.SetActive(true);
                    percentage += sign;
                    if (percentage >= 100 || percentage <= 0)
                    {
                        sign *= -1;
                        percentage = ((percentage <= 0) ? 0 : 100);

                    }
                    power_Bar.fillAmount = percentage / 100;
                }
            }
            else if (dist[i] > chicken_Range)
            {
                isChick_close = false;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            for (int j = 0; j < chickens.Count; j++)
            {
                chickens[j].gameObject.GetComponent<EnemyBehaivour>().enabled = true;
            }

            if (power_Bar.fillAmount >= power_Goal.fillAmount && power_Bar.fillAmount <= power_Goal_Range.fillAmount)
            {
                Debug.Log("Caught!");
                power_Goal.fillAmount = Random.Range(0f, 1.0f);
                power_Goal_Range.fillAmount = power_Goal.fillAmount + 0.1f;

                foreach (GameObject chick in chickens)
                {
                    float close = Vector3.Distance(chick.transform.position, this.transform.position);
                    if (close < closest_Chick)
                    {
                        closest_Chick = close;
                        near_Chicken = chick;

                    }
                }

            }
            agent.SetDestination(store_Dest);

            power_Bar.gameObject.SetActive(false);
            power_Goal.gameObject.SetActive(false);
            power_Goal_Range.gameObject.SetActive(false);
            power_BG.gameObject.SetActive(false);
            percentage = 100;
            power_Bar.fillAmount = 1.0f;
        }
    }

    





    #region Alt Control Scheme
    ///
    //   private GameObject player;
    //   private Vector3 targetVel;
    //   private Rigidbody rb;
    //   private Vector3 m_Vel = Vector3.zero;

    //   [Range (0.0f,0.3f)] public float m_moveSmooth = 0.05f;
    //   private float m_horizontal = 0.0f;
    //   private float m_vertical = 0.0f;

    //// Use this for initialization
    //void Awake () {
    //       player = GameObject.FindGameObjectWithTag("Player");
    //       rb = player.GetComponent<Rigidbody>();
    //       targetVel = new Vector3(0, 0, 0);

    //   }

    //// Update is called once per frame
    //void Update () {
    //       m_horizontal = Input.GetAxisRaw("Horizontal");
    //       m_vertical = Input.GetAxisRaw("Vertical");
    //       Move(m_horizontal, m_vertical);        

    //}

    //   public void Move(float x, float z)
    //   {
    //       targetVel = new Vector3(x * 10f, targetVel.y, z * 10f);
    //       rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVel, ref m_Vel, m_moveSmooth);
    //   }
    #endregion

}
