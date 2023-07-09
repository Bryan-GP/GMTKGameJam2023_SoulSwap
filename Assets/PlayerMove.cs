using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float movespeed = 1f;
    public float jumpspeed = 0.2f;
    public float jumpHeight = 10f;
    public float acc = -9.8f;
    public float upPressedTime;
    public float upWindow = 2f;
    public float fallGravityScale = 10f;
    public Rigidbody2D rb;
    public Animator animator;
    
    public bool isJumping;

    Vector2 movement;

    void Update()
    {
        float xdirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xdirection  * movespeed, rb.velocity.y );
        animator.SetFloat("Horizontal",xdirection );
        animator.SetFloat("speed", rb.velocity.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            //rb.gravityScale = 
            float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            upPressedTime = 0;
        }

        if( isJumping )
        {
            upPressedTime += Time.deltaTime;
            if(upPressedTime < upWindow && Input.GetKeyUp(KeyCode.W))
            {
                //cancel jump
                rb.gravityScale = fallGravityScale;
            } 
            if(rb.velocity.y < 0)
            {
                rb.gravityScale = fallGravityScale;
                isJumping = false;
            }
        }
        
    }

    /*
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * movespeed, rb.velocity.y);
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("speed", rb.velocity.sqrMagnitude);



        if (Input.GetButtonDown("Vertical") && !isJumping)
        {
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * acc);
                isJumping = true;
                animator.SetFloat("Vertical", 1);
                //rb.velocity = rb.velocity * new Vector2(0, acc);
            }
            

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            //Debug.Log("Enter floor");
            isJumping = false;
        }
        
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            //Debug.Log("Exit floor");
            isJumping = true;
        }

    }

    void FixedUpdate()
    {
        //movement
        rb.MovePosition(  movespeed * Time.deltaTime * rb.velocity + rb.position );
    }

    */

}


