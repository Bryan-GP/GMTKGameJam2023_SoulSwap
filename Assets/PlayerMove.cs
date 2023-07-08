using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float movespeed = 1f;
    public float jumpspeed = 8f;
    public Rigidbody2D rb;
    //Transform ;
    public Animator animator;
    
    public bool isJumping;

    Vector2 movement;


    void Update()
    {
        //inputs
        movement.x = Input.GetAxisRaw("Horizontal");
        //
        if (Input.GetButtonDown("Jump") && !isJumping )
        {
            movement.y = Input.GetAxisRaw("Jump") * jumpspeed * Time.deltaTime;
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);


    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isJumping = false;
        }
        
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isJumping = true;
        }

    }

    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);
    }
}
