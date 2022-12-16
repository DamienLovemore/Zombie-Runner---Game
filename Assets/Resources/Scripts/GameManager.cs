using UnityEngine;

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
