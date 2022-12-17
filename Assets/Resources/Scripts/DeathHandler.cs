using UnityEngine;
using StarterAssets;

public class DeathHandler : MonoBehaviour
{
    [Header("Game canvas")]
    [Tooltip("The canvas that is the game over screen")]
    [SerializeField] private Canvas gameOverCanvas;
    [Tooltip("The canvas that have the gun reticle")]
    [SerializeField] private Canvas gunAimingCanvas;

    private FirstPersonController playerController;
    private WeaponSwitcher weaponSwitcher;

    void Start() 
    {
        //In the start it will not be visible or usable,
        //the game over screen
        this.gameOverCanvas.enabled = false;

        this.playerController = this.GetComponent<FirstPersonController>();
        this.weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
    }

    //On player death show the game over canvas, pauses
    //the game and unlock its mouse from aiming for
    //canvas clicking
    public void HandleDeath()
    {
        //Removes the weapon aim in the screen
        this.gunAimingCanvas.enabled = false;
        this.gameOverCanvas.enabled = true;

        //Pauses the game, so the enemy is not attacking
        //anymore
        Time.timeScale = 0;
        //Disables camera rotation
        this.playerController.enabled = false;
        //Disable weapon switching when dead
        this.weaponSwitcher.enabled = false;

        //Unlock the mouse cursor from weapon aiming to
        //allow the player to click on the canvas
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
