using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public Collider2D coll; /* Берем коллайдер GroundChekcerа */
    public LayerMask GroundLayers; /* Слои с "Землёй" */
    public float ClimbSpeed;

    private Rigidbody2D rb;
    private bool Grounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        //Передвижение персонажа

        float move = Input.GetAxis("Horizontal");
        Vector2 Movement = new Vector2(move * Speed, rb.velocity.y);
        rb.velocity = Movement;

        //Карабканье по стенам при нажатии C

        float climb = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.C))
        {
            rb.velocity = new Vector2(move * ClimbSpeed, climb * ClimbSpeed);

            if ((climb) == -0.0f)
            {

                rb.AddForce(new Vector2(0.0f, -(rb.mass * rb.gravityScale * -9.81f)), ForceMode2D.Force );

            }
        }

        //Проверка на взаимодействия коллайдера GroundChekcerа со слоями земли

        Grounded = coll.IsTouchingLayers(GroundLayers); 
    }

    private void Update()
    {
        //Прыжки

        if (Input.GetButtonDown("Jump") && Grounded)
        {
            rb.AddForce(new Vector2(0.0f, JumpForce), ForceMode2D.Impulse);
        }

        
    }

}
