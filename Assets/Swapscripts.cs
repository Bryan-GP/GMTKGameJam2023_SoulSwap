using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Swapscripts : MonoBehaviour
{

    public int index = 0;
    public GameObject[] enemies_in_range;
    public GameObject Pointer;
    public GameObject chosenEnemy;
    public void addsoulscript()
    {
        if (index > enemies_in_range.Length || enemies_in_range.Length < 1)
        {
            return;
        }
        Pointer.transform.position = enemies_in_range[index].transform.position;
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            chosenEnemy = enemies_in_range[index];
        }

    }



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
}
