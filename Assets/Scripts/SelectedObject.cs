using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObject : MonoBehaviour
{

    //List of Selected Objects
    [SerializeField]
    private List<GameObject> selectedObjects;

    //List of Object Deselected this frame
    private List<GameObject> deSelectedObjects;

    [SerializeField]
    private LayerMask clickableLayer;   //Layer to only have raycast hits

    //Kep Track if object is selected
    private bool objectSelected = false;

    private void Start()
    {
        selectedObjects = new List<GameObject>();
        deSelectedObjects = new List<GameObject>();
    }

    private void Update()
    {
        IfLeftClicked();    //Check if left click happened
    }



    private void IfLeftClicked()
    {
        if (Input.GetMouseButtonDown(0))    //On Left Click
        {
            RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, clickableLayer)) //When Raycast hits something on correct layer
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
            else //Raycast Hits nothing
            {
                deSelectedObjects = new List<GameObject>(selectedObjects);
                selectedObjects.Clear();
            }

            //Let The Unselected Objects know they were unselected
            foreach (GameObject obj in deSelectedObjects)
            {
                obj.GetComponent<Selectable>().OnDeselect();
            }
            deSelectedObjects.Clear();

            //Reset Object Selected
            objectSelected = false;

        }
    }
}
