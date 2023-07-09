using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] tagslist;
    private int index = 0;
    private bool showfirst = true;
    public GameObject first;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!showfirst)
        {
            first.SetActive(false);
        }

       
        if (Input.GetKeyDown(KeyCode.Space) && showfirst == true)
        {
            showfirst = false;
            tagslist[0].SetActive(true);
        }
              
        if (index == 0)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                tagslist[0].SetActive(false);
                index += 1;
                tagslist[1].SetActive(true);
            }
        }
        else if (index == 1)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                tagslist[1].SetActive(false);
                index += 1;
                tagslist[2].SetActive(true);
            }
        }
    }
}
