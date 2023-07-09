using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGuyAI : MonoBehaviour
{
    //this guy can only move left and right and no jump
    //goes after blues
    //slow asf
    //strong asf

    [SerializeField] float speed = 1f;
    Rigidbody2D rb;
    //BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //bc = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRight())
        {
            rb.velocity = new Vector2(speed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0f);
        }
        
    }

    private bool IsRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
;    }
}
