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

    //Zoom in and out with the weapon when the player
    //pressed the right mouse button
    void OnZoom()
    {
        if (this.zoomToggle == false)
        {
            this.fpsCamera.m_Lens.FieldOfView = this.ZoomInFOV;
            this.zoomToggle = true;
        }
        else
        {
            this.fpsCamera.m_Lens.FieldOfView = this.ZoomOutFOV;
            this.zoomToggle = false;
        }
    }
}
