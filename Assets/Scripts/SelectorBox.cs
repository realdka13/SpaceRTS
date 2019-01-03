using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorBox : MonoBehaviour
{
    [SerializeField]
    private RectTransform selectionBoxImage;

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 squareStart;

    private void Start()
    {
        selectionBoxImage.gameObject.SetActive(false);  //Disable On Start
    }

    private void Update()
    {
        ShowSelectionBox();
    }

    private void ShowSelectionBox()
    {
        if (Input.GetMouseButtonDown(0))    //LMB Down
        {
                startPos = Input.mousePosition; //Box Start Position
            squareStart = startPos; //Make A Start Vector on the screen
                squareStart.z = 0f;
        }
        if (Input.GetMouseButtonUp(0))   //LMB Up
        {
            selectionBoxImage.gameObject.SetActive(false);
            squareStart = new Vector3(0, 0, 0);
        }
        if (Input.GetMouseButton(0))    //LMB Being Held Down
        {
            if (!selectionBoxImage.gameObject.activeInHierarchy)//Set active if not already active
            {
                selectionBoxImage.gameObject.SetActive(true);
            }
            endPos = Input.mousePosition; //Box End Position

            Vector3 center = (squareStart + endPos) / 2f; //Find Center of square

            selectionBoxImage.position = center; //Places square in correct location to avoid the square scaling from both sides

            //Find Square Sizes
            float sizex = Mathf.Abs(squareStart.x - endPos.x);
            float sizey = Mathf.Abs(squareStart.y - endPos.y);

            //Change Square Size
            selectionBoxImage.sizeDelta = new Vector2(sizex, sizey);

        }

    }
}
