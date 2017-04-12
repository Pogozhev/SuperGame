using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoupeClimb : MonoBehaviour
{

    public Transform StartPoint;
    public Transform EndPoint;
    public Transform EndTp;
    public Transform[] Points = new Transform[0];
    public Texture2D STRELKAa;
    public Texture2D STRELKAb;

    GameObject player;
    PlayerController playerController;
    private bool StartClimb = false;
    private bool climbing = false;
    private bool react = true;
    private bool DrawA = false;
    private bool DrawB = false;

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
            StartCoroutine(climb());           
        }

        if(!climbing)
        {
            playerController.StopFlip = false;
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

    IEnumerator climb()
    {
        playerController.StopFlip = true;
        StartCoroutine(React());
        StartClimb = false;
        for (int i = 0; i < Points.Length; i++)
        {
            react = false;         
            yield return new WaitForSeconds(Random.Range(1, 2));
                if (react)
                {
                    player.transform.position = Points[i].position;
                }
            else
            {
                climbing = false;
                playerController.Rb.isKinematic = false;
                StopAllCoroutines();
                DrawA = false;
                DrawB = false;
} 
        }
        DrawA = false;
        DrawB = false;
        player.transform.position = EndPoint.position;
        player.transform.position = EndTp.position;
        climbing = false;
        playerController.Rb.isKinematic = false;
        StopAllCoroutines();
        yield return null;
    }

    IEnumerator React()
    {
        while(true)
        {
            DrawA = true;       
            if (Input.GetKeyDown(KeyCode.A))
            {
                DrawA = false;
                while(true)
                {
                    DrawB = true;                 
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        DrawB = false;
                        react = true;
                        break;
                    }
                    yield return null;              
                }
            }
            yield return null;                   
        }
    }

    private void OnGUI()
    {
        if (DrawA)
        {
            GUI.DrawTexture(new Rect((Screen.resolutions[0].width / 2), (Screen.resolutions[0].height / 4), 200, 300), STRELKAa, ScaleMode.ScaleToFit, true, 0);
        }

        if (DrawB)
        {
            GUI.DrawTexture(new Rect((Screen.resolutions[0].width / 2), (Screen.resolutions[0].height / 4), 200, 300), STRELKAb, ScaleMode.ScaleToFit, true, 0);
        }
    }
}



