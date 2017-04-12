using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoupeClimb : MonoBehaviour {

    public Transform StartPoint;
    public Transform EndPoint;
    public Transform EndTp;
    public Transform[] Points = new Transform[0];

    GameObject player;
    PlayerController playerController;
    private bool StartClimb = false;
    private bool climbing = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (climbing)
        {
            playerController.Rb.velocity = new Vector2(0.0f, 0.0f);
            playerController.Rb.isKinematic = true;
        }
    }

    private void Update()
    {        

        if (StartClimb)
        {
            player.transform.position = StartPoint.position;
        }

        if (StartClimb)
        { 
            //climb();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            climbing = true;
            StartClimb = true;
        }
    }
   
//    void climb()
//    {
//        float time;
//        StartClimb = false;
//        for (int i = 0; i < Points.Length; i++)
//        {
//            time = Time.time;
//            StartCoroutine(dos(time, i));                                    
//        }
//        StopCoroutine(dos(0,0));

//        player.transform.position = EndPoint.position;
//        player.transform.position = EndTp.position;
//        climbing = false;
//        playerController.Rb.isKinematic = false;  
//    }

//    IEnumerator dos(float time, int i)
//    {
//        while(true)
//        {
//            while (time + Random.Range(1.0f, 2.0f) > Time.time)
//            {
//                Debug.LogWarning("123");
//                if (Input.GetKeyUp(KeyCode.A))
//                {
//                    player.transform.position = Points[i].position;
//                }
//                yield return null;
//            }
        
//        }       
//    }
}

