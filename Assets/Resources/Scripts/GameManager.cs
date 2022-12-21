using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private SceneLoader sceneLoader;

    void Start()
    {   
        this.sceneLoader = FindObjectOfType<SceneLoader>();
    }    

    void LateUpdate()
    {
        //Verifies if the player has achieved the goal
        this.VerifyWinningCondition();
    }

    //Process shortcuts hotkey like F11 and Esc keys
    private void OnProcessShortcuts()
    {
        //Quits the game
        if(Keyboard.current.escapeKey.isPressed)
        {
            this.QuitGame();
        }
        //Toggle window mode (fullscreen or windowed)
        else if (Keyboard.current.f11Key.isPressed)
        {
            this.ToggleWindowMode();
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void ToggleWindowMode()
    {
        //Gets the current window mode
        FullScreenMode currentScreenMode = Screen.fullScreenMode;
        
        //If it is in Fullscreen mode, then switch to windowed mode
        if((currentScreenMode != FullScreenMode.Windowed) && (currentScreenMode != FullScreenMode.MaximizedWindow))
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        //If it is in windowed mode, then switch to fullscreen mode
        else
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
    }

    //Verifies if there is no more enemies alive, then throws
    //the win trigger if true
    private void VerifyWinningCondition()
    {
        GameObject[] enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");
        
        if(enemiesAlive.Length == 0)
        {
            this.WinGame();
        }
    }

    private void WinGame()
    {
        this.sceneLoader.ReloadLevel();
    }
}
