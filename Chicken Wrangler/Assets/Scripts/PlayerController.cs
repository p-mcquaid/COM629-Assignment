using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent agent;
    public GameObject[] chickens = new GameObject[5];
    

    private bool isMiniGame = false;
    private Touch touch;

    void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("Camera").GetComponent<Camera>();
        for (int i = 0; i < chickens.Length; i++)
        {
            chickens = GameObject.FindGameObjectsWithTag("Chicken");
        }
        Debug.Log("Chickens.size: " + chickens.Length);
       
       
    }

    void FixedUpdate()
    {
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
        for (int i = 0; i < chickens.Length; i++)
        {
            //if (chickens[i].GetComponent<EnemyBehaivour>().isClose)
            //{
            //    if (Input.GetKeyDown(KeyCode.Space))
            //    {

            //        EB.gameObject.SetActive(false);

            //    }
            //}
        }
        if (isMiniGame)
        {
            this.gameObject.SetActive(false);
        }
        else if (true)
        {
            this.gameObject.SetActive(true);
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
