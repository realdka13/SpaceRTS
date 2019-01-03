using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selectable : MonoBehaviour
{
    //If Object is Selected Bool
    private bool isSelected = false;

    //Unit UI
    public Image selectedIcon;

    private void Start()
    {
        //Init
        isSelected = false;
        selectedIcon.enabled = false;
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
            selectedIcon.enabled = true;
        }
        else if (!isSelected)
        {
            selectedIcon.enabled = false;
        }
    }

}
