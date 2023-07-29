using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerMove : MonoBehaviour
{

    private playerRespawn respawnScript;        // Referencia al script playerRespawn
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    Rigidbody2D rb2D;
    public bool betterJump = false;
    public float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump;

    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        respawnScript = GetComponent<playerRespawn>();      // Obtiene la referencia al script playerRespawn
    }


    private void Update()
    {
        if (respawnScript.IsDead()) // Comprueba si el jugador ha muerto llamando a una función en el script playerRespawn
        {
            rb2D.velocity = Vector2.zero; // Detiene el movimiento del jugador
            return; // Sale de la función Update para evitar que el personaje se siga moviendo
        }


        if (Input.GetKey("space"))
        {
            if (checkGround.isGrounded)
            {
                canDoubleJump = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
        }


        if (checkGround.isGrounded == false)
        {
            animator.SetBool("isJump", true);
            animator.SetBool("isWalk", false);
        }
        if (checkGround.isGrounded == true)
        {
            animator.SetBool("isJump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("isFalling", false);
        }


        if (rb2D.velocity.y < 0)
        {
            animator.SetBool("isFalling", true);
        }

        if (rb2D.velocity.y > 0)
        {
            animator.SetBool("isFalling", false);
        }

    }

    void FixedUpdate()
    {
        if (respawnScript.IsDead()) // Comprueba si el jugador ha muerto llamando a una función en el script playerRespawn
        {
            rb2D.velocity = Vector2.zero; // Detiene el movimiento del jugador
            return; // Sale de la función Update para evitar que el personaje se siga moviendo
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("isWalk", true);

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("isWalk", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("isWalk", false);
        }

        if (betterJump)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            /* if (rb2D.velocity.y>0 && !Input.GetKey("space"))
             {
                 rb2D.velocity += Vector2.up* Physics2D.gravity.y * (mediumJumpMultiplier) * Time.deltaTime;
             }*/
            if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }

        }
    }
}




































/* void Update()
    {
      if (Input.GetKey(KeyCode.RightArrow))
      {
      gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime); 
      animCtrl.SetBool("isWalking",true);
      //gameObject.GetComponent<SpriteRenderer>().flipX = false;
      }

      else if (Input.GetKey(KeyCode.LeftArrow))
      {
      gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime); 
      animCtrl.SetBool("walkIzq",true);
     // gameObject.GetComponent<SpriteRenderer>().flipX = true;
      }

    else if (Input.GetKey(KeyCode.Space))
      {
      gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime); 
      animCtrl.SetBool("jumpingDer",true);
      }
      else{
      animCtrl.SetBool("isWalking",false);
      animCtrl.SetBool("walkIzq",false);
      animCtrl.SetBool("jumpingDer",false);*/