using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause_Menu;
    public static bool isPasued;
    public string currentScene;
    private void Awake()
    { currentScene = SceneManager.GetActiveScene().name; }
      
    public void restartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentScene);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            restartLevel();
        }
    }
}
