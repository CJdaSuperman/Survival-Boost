//Game manager will be in charge of setting mobile features into game and being the mediator between pause menu
//and other objects that need to know the status of pause menu

using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool isMobile;
    [SerializeField] GameObject thrustButton;
    [SerializeField] GameObject settingsButton;

    public ButtonHandler thrustButtonHandler { get; set; }

    PauseMenu pauseMenu;

    void Start()
    {
        thrustButtonHandler = thrustButton.GetComponent<ButtonHandler>();
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    public void TogglePauseMenu() => pauseMenu.TogglePauseMenu();   
    
    public void ActivateMobileButtons(bool b)
    {
        thrustButton.SetActive(b);
        settingsButton.SetActive(b);
    }
    
    public bool isGamePaused()
    {
        return pauseMenu.isGamePaused();
    }

    public bool isMobileControls()
    {
        return isMobile;
    }
}
