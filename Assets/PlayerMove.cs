using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float movespeed = 1f;
    public float jumpspeed = 0.2f;
    public float jumpHeight = 10f;
    public float upPressedTime;
    public float upWindow = 0.01f;
    public float fallGravityScale = 0.01f;

    public Rigidbody2D rb;
    public Animator animator;

    public bool onGround = true;
    public bool isJumping = false;

    void Update()
    {
        if (!PauseMenu.isPasued)
        {
            float xdirection = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(xdirection * movespeed , rb.velocity.y);
            animator.SetFloat("Horizontal", xdirection);
            animator.SetFloat("speed", rb.velocity.sqrMagnitude);

            if (Input.GetKeyDown(KeyCode.W) && onGround && !isJumping)
            {
                rb.gravityScale = fallGravityScale;
                float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                upPressedTime = 0;
                onGround = false;
                isJumping = true;

            }
            if (isJumping && !onGround)
            {

                upPressedTime += Time.deltaTime;
                if (upPressedTime < upWindow && Input.GetKeyUp(KeyCode.W))
                {
                    //cancel jump
                    rb.gravityScale = fallGravityScale;
                }
                else
                {
                    isJumping = false;
                    if (rb.velocity.y == 0)
                    {
                        onGround = true;
                    }
                }
                if (rb.velocity.y < 0)
                {
                    rb.gravityScale = fallGravityScale;
                    isJumping = false;
                    onGround = true;
                }
            }
            else if (rb.velocity.y == 0)
            {
                onGround = true;
            }
        }
    }

}
