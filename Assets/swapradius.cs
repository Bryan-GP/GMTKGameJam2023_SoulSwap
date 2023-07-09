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
    private GameObject parent;
    private Animator enemyanimator;
    public int index = 0;


    void turnoffai(GameObject enemy)
    {
        
        GameObject enemyai = enemy.transform.GetChild(1).gameObject;
        enemyai.SetActive(false);
    }

    void turnonai(GameObject enemy)
    {
        
        GameObject enemyai = enemy.transform.GetChild(1).gameObject;
        enemyai.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedEnemy") || collision.gameObject.CompareTag("BlueEnemy"))
        {
            enemies_in_range.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("RedEnemy") || collision.gameObject.CompareTag("BlueEnemy"))
        {
            if (enemies_in_range.Count > 0)
            {
                enemy = enemies_in_range[index];
                enemyanimator = enemy.GetComponent<Animator>();
                enemyanimator.SetBool("swapping", false);
            }
            enemies_in_range.Remove(collision.gameObject);
        }
    }

    public void chooseBody(GameObject enemy)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            parent = this.transform.parent.gameObject;
            enemyanimator.SetBool("swapping", false);
            GameObject enemysoul = enemy.transform.GetChild(0).gameObject;
            enemysoul.SetActive(true);
            //Debug.Log(enemysoul.activeSelf);
            GameObject myGameObject = this.gameObject;
            myGameObject.SetActive(false);
            turnoffai(enemy);


            //deactivates if its mainsoul
            if (parent.name == "MainSoul")
            {
                parent.SetActive(false);
            }
            else
            {
                turnonai(enemy);
            }
            Time.timeScale = 1f;

            enemy.SetActive(true);




        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0.10f)
        {
            if (enemies_in_range.Count > 0)
            {
                enemy = enemies_in_range[index];
                enemyanimator = enemy.GetComponent<Animator>();
                enemyanimator.SetBool("swapping", true);

                chooseBody(enemy);
            }
        } 
        else
        {

            if (enemies_in_range.Count > 0)
            {
                enemy = enemies_in_range[index];
                enemyanimator = enemy.GetComponent<Animator>();
                enemyanimator.SetBool("swapping", false);
            }
        }
         

        
    }
}