
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Soul : MonoBehaviour
{
    public bool swapping;
    

    //soul swap:
    //while holding down a button specifyed to soul swap  --y
    //choose an enemy that you want to soul swap to, they cant swap to a soul which is of the same colour, and they can change to a body of any colour when just a souly  --n
    //when swapped this script should be impelemted into thier object which overrides their own script --n
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            swapping = true;
            Time.timeScale = 0f;
  
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            swapping = false;
            Time.timeScale = 1f;
        }



    }
}

