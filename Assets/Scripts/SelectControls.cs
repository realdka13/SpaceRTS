using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectControls : MonoBehaviour
{

    //List of Selected Objects
    [SerializeField]
    private List<GameObject> selectedObjects;
    //List of Object Deselected this frame
    private List<GameObject> deSelectedObjects;

    //All of the Objects that are selectable
    [HideInInspector]
    public List<GameObject> selectableObjs;

    //Vectors for Finding MousePositions
    private Vector3 mousePos1;
    private Vector3 mousePos2;

    [SerializeField]
    private LayerMask clickableLayer;   //Layer to only have raycast hits

    //Kep Track if object is selected
    private bool objectSelected = false;

    private void Awake()
    {
        selectedObjects = new List<GameObject>();
        deSelectedObjects = new List<GameObject>();
        selectableObjs = new List<GameObject>();
    }

    private void Update()
    {
        IfLeftClicked();    //Check if left click happened
        ShouldClearSelection();
    }

    private void ShouldClearSelection()
    {
        if (Input.GetButtonDown("Deselect All"))
        {
            deSelectedObjects = new List<GameObject>(selectedObjects);
            selectedObjects.Clear();
            UpdateDeselections();
        }
    }

    private void SelectObjects() //For box selecting
    {
        List<GameObject> remObjects = new List<GameObject>(); //Keeping track of which objects are destroyed while iterating, to be removed after

        if (Input.GetButton("Toggle Select") == false) //If Toggle Key not Pressed
        {
            deSelectedObjects = new List<GameObject>(selectedObjects);
            selectedObjects.Clear();
            UpdateDeselections();
        }

        Rect selectRect = new Rect(mousePos1.x, mousePos1.y,mousePos2.x - mousePos1.x, mousePos2.y - mousePos1.y); //Create Invisible Box for Selecting

        foreach (GameObject selectObject in selectableObjs)
        {
            if (selectObject != null) //Check if deleting while iterating
            {
                if (selectRect.Contains(Camera.main.WorldToViewportPoint(selectObject.transform.position), true))
                {
                    selectedObjects.Add(selectObject);
                    selectObject.GetComponent<Selectable>().OnSelected(); //Tell Them Theyve Been Selected
                }
            }
            else //If Objct is null
            {
                remObjects.Add(selectObject);
            }
        }
        if (remObjects.Count > 0) //Remove the Nulled Objects
        {
            foreach (GameObject rem in remObjects)
            {
                selectedObjects.Remove(rem);
            }
            remObjects.Clear();
        }
    }

    private void IfLeftClicked()
    {
        if (Input.GetMouseButtonDown(0))    //On Left Click
        {
            mousePos1 = Camera.main.ScreenToViewportPoint(Input.mousePosition); //Get first mouse position the moment the mouse button is pressed(for drag)

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit rayHit, Mathf.Infinity, clickableLayer)) //When Raycast hits something on correct layer
            {
                objectSelected = rayHit.collider.GetComponent<Selectable>().OnClicked();
                if (Input.GetButton("Toggle Select"))   //If Toggle Key Pressed
                {
                    if (objectSelected) //And the object is being selected
                    {
                        //Add without anything special
                        selectedObjects.Add(rayHit.collider.gameObject);
                    }

                    else if (!objectSelected) //And Object is being deselected
                    {
                        //Subjtract without anything special
                        selectedObjects.Remove(rayHit.collider.gameObject);

                        deSelectedObjects.Add(rayHit.collider.gameObject); //Add it to deselected Objects
                    }
                }
                else if (objectSelected)
                {
                    if (selectedObjects.Count > 0)
                    {
                        //Add everything from list to deselected Objects
                        deSelectedObjects = new List<GameObject>(selectedObjects);
                        //Clear list currently
                        selectedObjects.Clear();
                    }

                    //Add To List
                    selectedObjects.Add(rayHit.collider.gameObject);
                    deSelectedObjects.Remove(rayHit.collider.gameObject);//remove the just added object from deselectred objects

                }
                else if (!objectSelected)
                {
                    deSelectedObjects = new List<GameObject>(selectedObjects);

                    //Clear list
                    selectedObjects.Clear();
                }
            }

            UpdateDeselections();

        }
        if (Input.GetMouseButtonUp(0)) //When Mouse button is released
        {
            mousePos2 = Camera.main.ScreenToViewportPoint(Input.mousePosition); //Set Final mouse Pos(for drag)
            if (mousePos1 != mousePos2) //Dont do it just a plain click
            {
                SelectObjects();
            }
        }
        //Reset Object Selected
        objectSelected = false;
    }

    private void UpdateDeselections() //Used to let the objects know theyve been deselected
    {
        //Let The Unselected Objects know they were unselected
        foreach (GameObject obj in deSelectedObjects)
        {
            obj.GetComponent<Selectable>().OnDeselect();
        }
        deSelectedObjects.Clear();
    }
}
