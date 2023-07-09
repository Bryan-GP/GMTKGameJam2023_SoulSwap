
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGuyAI : MonoBehaviour
{
    //this guy can only move left and right and no jump
    //goes after blues
    //slow asf
    //strong asf

    public float speed = 1.5f;
    public float restspeed = 0.5f;
    public float redGuyrange = 10f;
    Rigidbody2D rb;
    CircleCollider2D circle;
    public List<GameObject> enemy;
    //public bool targetLock;
    public GameObject enemyTarget;
    [SerializeField] private int enemyIndex;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();

    }

   
    private bool IsRight()
    {
        return enemyTarget.transform.localScale.x > Mathf.Epsilon;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedEnemy"))
        {
            enemy.Add(collision.gameObject);
            enemyIndex++;
            enemyTarget = enemy[0];
            //targetLock = true;

        }
        //this.transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), this.transform.localScale.y);  //this line is for patrollling

    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("RedEnemy"))
        {
            if (enemy.Count > 0)
            {
                enemy.Remove(collision.gameObject);
                enemyIndex--;

            }

        }
    }
    void Update()
    {
        if (enemy.Count < 0)
        {
            //this.transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), this.transform.localScale.y);  //this line is for flipping direction
            rb.velocity = new Vector2(restspeed, rb.velocity.y);
        }
        if (IsRight())
        {
            rb.velocity = new Vector2(speed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0f);
        }

    }

}
