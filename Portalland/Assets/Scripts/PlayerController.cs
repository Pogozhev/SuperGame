using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public Transform Checker1; /* Берем коллайдер GroundChekcerа */
    public Transform Checker2;
    public LayerMask GroundLayers; /* Слои с "Землёй" */
    //public float ClimbSpeed;
    //public LayerMask ladder;

    private bool rotated = false;
    private Rigidbody2D rb;
    private bool Grounded;
    //private bool LadderEnter = false;
    private bool stopFlip = false;

    public Rigidbody2D Rb
    {
        get
        {
            return rb;
        }

        set
        {
            rb = value;
        }
    }

    public bool StopFlip
    {
        get
        {
            return stopFlip;
        }

        set
        {
            stopFlip = value;
        }
    }

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Проверка на взаимодействия коллайдера GroundChekcerа со слоями земли

        Grounded = Physics2D.OverlapCircle(Checker1.transform.position, 0.09f, GroundLayers);

        //Передвижение персонажа

        float move = Input.GetAxis("Horizontal");
        Vector2 Movement = new Vector2(move * Speed, Rb.velocity.y);
        Rb.velocity = Movement;

        //Лазанье по лестницам

        //CheckLadder();

        //if (LadderEnter)
        //{
        //    float climb = Input.GetAxis("Vertical");

        //    if (climb >= 0.0f)
        //    {
        //        LadderUP(move, climb);
        //    }

        //    if (climb < 0.0f)
        //    {
        //        LadderDOWN(move, climb);
        //    }
        //}


        //if (Grounded && !LadderEnter)
        //{
        //    Physics2D.IgnoreLayerCollision(10, 8, false); /* "10" слой с игроком "8" слой с землей*/
        //}

        //Поворот персонажа

        if (Rb.velocity.x > 0 & rotated & !StopFlip) Flip();
        else if (Rb.velocity.x < 0 & !rotated & !StopFlip) Flip();
    }

    private void Update()
    {
        //Прыжки

        if (Input.GetButtonDown("Jump") && Grounded)
        {
            Rb.AddForce(new Vector2(0.0f, JumpForce), ForceMode2D.Impulse);
        }      
    }

    //private void CheckLadder()
    //{
    //    if (Physics2D.OverlapCircle(Checker1.transform.position, 0.09f, ladder))
    //    {
    //        LadderEnter = true;
    //    }
    //    else LadderEnter = false;
    //}


    //private void LadderUP(float move, float climb)
    //{    
           
    //    Rb.velocity = new Vector2(move * ClimbSpeed, climb * ClimbSpeed);

    //    if (Physics2D.OverlapCircle(Checker2.transform.position, 0.09f, GroundLayers))
    //    {
    //        Physics2D.IgnoreLayerCollision(10,8, true); /* "10" слой с игроком "8" слой с землей*/
    //    }

    //    if ((climb) == 0.0f)
    //    {
    //        Rb.AddForce(new Vector2(0.0f, -(Rb.mass * Rb.gravityScale * -9.81f)), ForceMode2D.Force);
    //    }

    //    if (Grounded)
    //    {
    //        Physics2D.IgnoreLayerCollision(10, 8, false); /* "10" слой с игроком "8" слой с землей*/
    //    }
    //}

    //private void LadderDOWN(float move, float climb)
    //{
    //    Rb.velocity = new Vector2(move * ClimbSpeed, climb * ClimbSpeed);

    //    if (Physics2D.OverlapCircle(Checker1.transform.position, 0.09f, GroundLayers))
    //    {
    //        Physics2D.IgnoreLayerCollision(10, 8, true); /* "10" слой с игроком "8" слой с землей*/
    //    }

    //    if (Physics2D.OverlapCircle(Checker1.transform.position, 0.09f, ladder) && Physics2D.OverlapCircle(Checker2.transform.position, 0.09f, ladder))
    //    {
    //        Physics2D.IgnoreLayerCollision(10, 8, false); /* "10" слой с игроком "8" слой с землей*/
    //    }
    //}

    private void Flip()
    {
        Vector3 Scale = new Vector3(-(gameObject.transform.localScale.x), (gameObject.transform.localScale.y), (gameObject.transform.localScale.z));

        gameObject.transform.localScale = Scale;

        rotated = !rotated;
    }
}
