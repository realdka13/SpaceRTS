using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    //Mats
    [SerializeField]
    private Material selectedMat;
    [SerializeField]
    private Material unselectedMat;

    //If Object is Selected Bool
    [SerializeField]
    private bool isSelected = false;

    //Mesh Renderer for changing colors
    private MeshRenderer meshRend;

    private void Start()
    {
        //Find Mesh Renderer
        meshRend = GetComponent<MeshRenderer>();

        //Initializing
        meshRend.material = unselectedMat;
        isSelected = false;
    }

    public bool OnClicked() //Is Toggle Button Held
    {
        if (isSelected)
        {
            OnDeselect();
        }
        else if (!isSelected)  //If it is not selected, select it
        {
            OnSelected();
        }
        return isSelected; //Tell if gameobject hit is selected or unselected
    }

    public void OnSelected()
    {
        isSelected = true;
        UpdateSelectionSign();
    }

    public void OnDeselect()
    {
        isSelected = false;
        UpdateSelectionSign();
    }

    public void UpdateSelectionSign()
    {
        if (isSelected)
        {
            meshRend.material = selectedMat;
        }
        else if (!isSelected)
        {
            meshRend.material = unselectedMat;
        }
    }

}
