using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
            
        }
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    void Paused()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        IsPaused = true;
        Debug.Log(IsPaused);
    }
    void Resume()
    {
     PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        Debug.Log(IsPaused);
    }
    

}
