using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    //Zoom vars
    private readonly float minFOV = 20f;
    private readonly float maxFOV = 75f;

    //Mouse Drag vars
    private readonly float zoomSpeed = -30f;//Negative To inverse Direction
    private readonly float mouseDragSpeed = 2f;

    //Screen Bound Move Vars
    private readonly float mouseScreenSpeed = 50f;
    private readonly float borderSize = 50f;

    private void LateUpdate()
    {
        ZoomCamera();
        MiddleMouseCameraMovement();
        MouseBoundryKeyboardMovement();
    }

    private void MouseBoundryKeyboardMovement()
    {
        //Keyboard Controls
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Camera.main.transform.position += new Vector3(0,0, mouseScreenSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Camera.main.transform.position -= new Vector3(0, 0, mouseScreenSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Camera.main.transform.position += new Vector3(mouseScreenSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Camera.main.transform.position -= new Vector3(mouseScreenSpeed * Time.deltaTime, 0, 0);
        }

        //Screen Border Movement
        if (Input.mousePosition.x > Screen.width - borderSize) //Moving Right
        {
            Camera.main.transform.position += new Vector3(mouseScreenSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.mousePosition.x < borderSize) //Moving Left
        {
            Camera.main.transform.position -= new Vector3(mouseScreenSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.mousePosition.y > Screen.height - borderSize) //Moving Up
        {
            Camera.main.transform.position += new Vector3(0, 0, mouseScreenSpeed * Time.deltaTime);
        }
        if (Input.mousePosition.y < borderSize) //Moving Down
        {
            Camera.main.transform.position -= new Vector3(0, 0, mouseScreenSpeed * Time.deltaTime);
        }
    }

    private void MiddleMouseCameraMovement()
    {
        if (Input.GetMouseButton(2))
        {
            Camera.main.transform.position -= new Vector3(Input.GetAxis("Mouse X") * mouseDragSpeed, 0, Input.GetAxis("Mouse Y") * mouseDragSpeed);
        }
    }

    private void ZoomCamera()
    {
        float fov = Camera.main.GetComponent<Camera>().fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.GetComponent<Camera>().fieldOfView = fov;
    }
}
