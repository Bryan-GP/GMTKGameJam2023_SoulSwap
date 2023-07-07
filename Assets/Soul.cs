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
    private float[] dist;
    public List<GameObject> enemies_in_range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //soul swap:
    //while holding down a button specifyed to soul swap  --y
    //choose an enemy that you want to soul swap to, they cant swap to a soul which is of the same colour, and they can change to a body of any colour when just a souly  --n
    //when swapped this script should be impelemted into thier object which overrides their own script --n
  
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            swapping = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            swapping = false;
        }
        while (swapping)
        {
            try
            {
                enemyList = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < enemyList.Length; i++)
                {
                    dist[i] = Vector2.Distance(transform.position, enemyList[i].transform.position);
                    if (dist[i] <= range)
                    {
                        enemies_in_range.Add(enemyList[i]);

                    }
                }
            }
            catch(NullReferenceException x)
            {
                print(x.Message);
            }
        }
    }
}
