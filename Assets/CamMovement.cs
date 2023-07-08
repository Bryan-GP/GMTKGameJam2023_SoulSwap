using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float camspeed = 2f;
    public Transform target = null;
    public GameObject targetobj = null;


    private void Start()
    {
        targetobj = GameObject.FindGameObjectWithTag("Soul");
        target = targetobj.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        targetobj = GameObject.FindGameObjectWithTag("Soul");
        target = targetobj.GetComponent<Transform>();

        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);

        transform.position = Vector3.Slerp(transform.position, newPos, camspeed * Time.deltaTime);
    }
}
