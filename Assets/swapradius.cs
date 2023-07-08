using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapradius : MonoBehaviour
{

    
    public GameObject[] enemyList;
    public List<GameObject> enemies_in_range;
    public Collider2D radius;
    public int index = 0; 

    
      


    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0.05f)
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                index -= 1;
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                index += 1;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemies_in_range.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemies_in_range.Remove(collision.gameObject);
        }
    }
}
