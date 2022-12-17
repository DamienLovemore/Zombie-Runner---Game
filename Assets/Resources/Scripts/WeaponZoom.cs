using UnityEngine;
using Cinemachine;

public class WeaponZoom : MonoBehaviour
{
    [Header("Aim target")]
    //When you use cinemachine you cannot alter FOV directly on
    //the main camera
    [Tooltip("The camera that follows the player")]
    [SerializeField] private CinemachineVirtualCamera fpsCamera;

    [Header("Zoom config")]
    [Tooltip("How close it should zoom into the player")]
    [SerializeField] private float ZoomInFOV = 20f;
    [Tooltip("How far away it should go from the player on zoom out")]
    [SerializeField] private float ZoomOutFOV = 40f;

    private bool zoomToggle = false;

    //Upon weapon switch disables the zoom
    //(Because the other types of weapon, does not have zoom)
    void OnDisable() 
    {
        this.ZoomOut();
    }

    //Zoom in and out with the weapon when the player
    //pressed the right mouse button
    void OnZoom()
    {
        if (this.zoomToggle == false)
        {
            this.ZoomIn();
        }
        else
        {
            this.ZoomOut();
        }
    }

    private void ZoomIn()
    {
        this.fpsCamera.m_Lens.FieldOfView = this.ZoomInFOV;
        this.zoomToggle = true;
    }

    private void ZoomOut()
    {
        this.fpsCamera.m_Lens.FieldOfView = this.ZoomOutFOV;
        this.zoomToggle = false;
    }
}
