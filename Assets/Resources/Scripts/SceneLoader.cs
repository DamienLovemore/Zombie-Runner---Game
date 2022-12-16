using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Starts the game from the beginning
    public void ReloadLevel()
    {
        //Reloads the game (current level/scene)
        Scene actualLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actualLevel.buildIndex);

        //Resume the game
        Time.timeScale = 1;
        
        //Returns the mouse to its original state
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //Closes the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
