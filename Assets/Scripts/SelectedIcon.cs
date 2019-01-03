using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedIcon : MonoBehaviour
{
    //Orient the camera after all movement is completed this frame to avoid jittering

    //TODO Remove this if not needed (Orients the selected icon towards the player camera)

    private Camera playerCamera;

    private void Start()
    {
        playerCamera = FindObjectOfType<Camera>();
    }


    private void LateUpdate()
    {
        //transform.LookAt(transform.position + playerCamera.transform.rotation * Vector3.forward,playerCamera.transform.rotation * Vector3.up);
    }
}
