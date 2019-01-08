using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableBuilding : MonoBehaviour
{
    private bool isSelected;

    [SerializeField]
    private GameObject selectedIcon;

    private void Start()
    {
        //Set Icon to Off by default
        isSelected = false;
        selectedIcon.SetActive(false);
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
            selectedIcon.SetActive(true);
        }
        else if (!isSelected)
        {
            selectedIcon.SetActive(false);
        }
    }
}