using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapradius : MonoBehaviour
{

    
    public GameObject[] enemyList;
    public List<GameObject> enemies_in_range;
    public Collider2D radius;

    
      


    // Update is called once per frame
    void Update()
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
            Debug.Log("Real");
        }
    }
}
