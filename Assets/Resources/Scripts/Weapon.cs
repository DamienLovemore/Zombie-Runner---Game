using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera FPCamera;
    [SerializeField] private float bulletRange = 100f;

    void Update()
    {
        
    }

    private void OnFire()
    {
        RaycastHit hit;
        bool hittedSomething;

        //Cast a invisible ray into a direction to see if it hits something
        //Starting position, ray direction, ray hit information  and how far it should go
        //(When using ray direction use GameObject.transform.direction, not Vector3.direction,
        //to consider its rotation and actual position in the world)
        hittedSomething = Physics.Raycast(this.FPCamera.transform.position, this.FPCamera.transform.forward, out hit, bulletRange);
        
        if(hittedSomething)
        {
            Debug.Log($"Hitted something: {hit.transform.name}");
        }
    }
}
