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
    private GameObject enemy;

    public GameObject camera;

    private Animator enemyanimator;
    //public GameObject pointer;
    //public GameObject chosen;


    public int index = 0;



    public void changeCam()
    {

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

    public void chooseBody(GameObject enemy)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            enemyanimator.SetBool("swapping", false);
            GameObject enemysoul = enemy.transform.GetChild(0).gameObject;
            enemysoul.SetActive(true);
            //Debug.Log(enemysoul.activeSelf);
            GameObject myGameObject = this.gameObject;
            myGameObject.SetActive(false);
            Time.timeScale = 1f;

            enemy.SetActive(true);




        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0.05f)
        {
                enemy = enemies_in_range[index];
                enemyanimator = enemy.GetComponent<Animator>();
                enemyanimator.SetBool("swapping", true);

           
                
                

            if (Input.GetKeyUp(KeyCode.Q) && index >= 1)
            {
                    enemyanimator.SetBool("swapping", false);
                    index -= 1;
                    Debug.Log("part2" + enemies_in_range);
                    enemy = enemies_in_range[index];
                    enemyanimator.SetBool("swapping", true);


            }
            else if (Input.GetKeyUp(KeyCode.E) && index < enemies_in_range.Count - 1)
            {
                    enemyanimator.SetBool("swapping", false);
                    index += 1;
                    Debug.Log("part2" + enemies_in_range);
                    enemy = enemies_in_range[index];
                    enemyanimator = enemy.GetComponent<Animator>();
                    enemyanimator.SetBool("swapping", true);

            }
            chooseBody(enemy);
        }

        
    }
}