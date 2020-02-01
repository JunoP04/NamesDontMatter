using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void unPauseGame()
    {
        Time.timeScale = 1;
    }

}
