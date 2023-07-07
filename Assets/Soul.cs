
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Soul : MonoBehaviour
{
    public bool swapping;
    public float range;
    public GameObject[] enemyList;
    public List<float> dist;
    public List<GameObject> enemies_in_range1;
    public GameObject[] enemies_in_range2;
    public GameObject chosenEnemy;
    public GameObject preivousSelf;
  


 

    //soul swap:
    //while holding down a button specifyed to soul swap  --y
    //choose an enemy that you want to soul swap to, they cant swap to a soul which is of the same colour, and they can change to a body of any colour when just a souly  --n
    //when swapped this script should be impelemted into thier object which overrides their own script --n
  
    public void getEnemies()
    {
        if (swapping)
        {
            enemyList = GameObject.FindGameObjectsWithTag("Enemy");
            print(enemyList);
            for (int i = 0; i < enemyList.Length; i++)
            {
                dist[i] = Vector2.Distance(transform.position, enemyList[i].transform.position);
                print(dist);
                if (dist[i] <= range)
                {
                    enemies_in_range1.Add(enemyList[i]);


                }
            }
        }
        enemies_in_range2 = enemies_in_range1.ToArray();
        print(enemies_in_range2.Length);
        return;
    }
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            swapping = true;
            Time.timeScale = 0f;
            getEnemies();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            swapping = false;
            Time.timeScale = 1f;
        }



    }
}

