using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapradius : MonoBehaviour
{

    public bool swapping;
    public float range;
    public GameObject[] enemyList;
    public float[] dist;
    public List<GameObject> enemies_in_range;
    public GameObject Pointer;
    public GameObject chosenEnemy;
    public GameObject preivousSelf;
    public int index = 0;
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
