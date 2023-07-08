using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plankbreak : MonoBehaviour
{
    
    public Animator animator;
    public Collider2D collider;
    private float count = 0;
    private bool inrange = false;
    
    void breakplank()
        {
           count = 0;
           animator.SetBool("Breaking", true);
        
        }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("RedEnemy"))
        {
            inrange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("RedEnemy"))
        {
            inrange = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (inrange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                breakplank();
            }
        }
    }
}
