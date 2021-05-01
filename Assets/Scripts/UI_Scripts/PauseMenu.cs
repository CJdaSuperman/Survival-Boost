using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;

    bool gamePaused = false;

    void Start() => Time.timeScale = 1f;    

    public void TogglePauseMenu()
    {
        pauseCanvas.SetActive(!pauseCanvas.activeSelf);
        PauseGame();
    }

    public void PauseGame()
    {
        if (pauseCanvas.activeSelf)
        {
            Time.timeScale = 0f;
            gamePaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            gamePaused = false;
        }
    }

    public void Quit() => Application.Quit();            

    public bool isGamePaused()
    {
        return gamePaused;
    }
}
