using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitportal : MonoBehaviour
{
    private Scenemanagment refScript;
    public string nextlevel;

    void OnTriggerEnter2D(Collider2D collider)
    {
        refScript = this.GetComponent<Scenemanagment>();
        if (collider.gameObject.CompareTag("RedEnemy") || collider.gameObject.CompareTag("BlueEnemy"))
        {
            refScript.GotoScene(nextlevel);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
