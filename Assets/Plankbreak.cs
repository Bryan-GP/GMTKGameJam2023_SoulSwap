using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plankbreak : MonoBehaviour
{
    
    public Animator animator;
    public Collider2D collider;
    private float count = 0;
    
    void breakplank()
        {
        if (Input.GetKeyDown(KeyCode.E))
        {
            count = 0;
            animator.SetBool("Breaking", true);
            GameObject myGameObject = this.gameObject;
            while (count < 3)
            {
                count += Time.deltaTime;
                if (count > 2)
                {
                    animator.SetBool("Breaking", false);
                }

            }
            myGameObject.SetActive(false);
        }
        }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("RedEnemy"))
        {
            breakplank();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
