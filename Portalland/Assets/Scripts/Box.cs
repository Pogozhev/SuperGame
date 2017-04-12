using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    //Пока нигде не используется и наверное не будет

    private Rigidbody2D rbBox;
    private GameObject Player;
    private bool BoxEnter = false;
    PlayerController playerController;

    private void Start()
    {
        rbBox = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        playerController = Player.GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {        
        Rigidbody2D PlayerVelocity = playerController.Rb;

        if (BoxEnter & Input.GetKey(KeyCode.F) )
        {
            PlayerVelocity.velocity = new Vector2(PlayerVelocity.velocity.x * 0.1f, PlayerVelocity.velocity.y);
            rbBox.velocity = new Vector2(PlayerVelocity.velocity.x, 0.0f);          
        }     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Hand")
        {
            BoxEnter = true;
            playerController.BoxEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Hand")
        {
            BoxEnter = false;
            playerController.BoxEnter = false;
        }
    }
}
