using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanagment : MonoBehaviour
{
    public void GotoScene(string Scenename)
    {
        SceneManager.LoadScene(Scenename);
    }
}
