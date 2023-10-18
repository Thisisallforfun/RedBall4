using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPauseGame = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameplayMenu;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        isPauseGame = false;
        gameplayMenu.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        isPauseGame = true;
        gameplayMenu.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Selection");
    }
}
