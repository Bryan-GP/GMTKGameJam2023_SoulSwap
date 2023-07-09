using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause_Menu;
    public static bool isPasued;
    public string currentScene = SceneManager.GetActiveScene().name;

    // Start is called before the first frame update
    void Start()
    {
        Pause_Menu.SetActive(false);
        
    }

    public void PauseGame()
    {
        Pause_Menu.SetActive(true);
        Time.timeScale = 0f;
        isPasued = true;
    }

    public void ResumeGame()
    {
        Pause_Menu.SetActive(false);
        Time.timeScale = 1f;
        isPasued = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPasued)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }
    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {

    }

    public void restartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentScene);
    }
}
