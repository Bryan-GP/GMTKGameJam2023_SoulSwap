using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class swapradius : MonoBehaviour
{

    [SerializeField] public GameObject now;
    public GameObject[] enemyList;
    public List<GameObject> enemies_in_range;
    public Collider2D radius;
    //public GameObject pointer;
    //public GameObject chosen;

    public int index = 0;


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

    public void chooseBody()
    {
        //enemies_in_range[index].transform.position;
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(enemies_in_range);
            enemies_in_range[index].gameObject.SetActive(true);/////////////////////////////////////////////////////////////////////////////--here is needed to be changed 
            Time.timeScale = 1f;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0.05f)
        {
            Debug.Log("part1"); 
            Debug.Log(enemies_in_range);
            if (Input.GetKeyUp(KeyCode.Q) && index >= 1)
            {
                index -= 1;
                Debug.Log("part2" + enemies_in_range);
                
                
            }
            else if (Input.GetKeyUp(KeyCode.E) && index < enemies_in_range.Count-1)
            {
                index += 1;
                Debug.Log("part2" + enemies_in_range);
                
            }
            chooseBody();
        }

    }
}
