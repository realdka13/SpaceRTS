using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationGrid : MonoBehaviour
{
    private GridLayout formationGrid;
    public GameObject somePrefab;
    [SerializeField]
    private LayerMask clickableLayer;

    //For finding the locations spawning
    private int currentXPos;
    private int currentYPos;
    private readonly int zPos = 0;

    //Calculation Variables
    private int totalIndex;
    private int currentIndex;
    private bool xPlusbool;
    private bool xMinusbool;
    private bool yPlusbool;
    private bool yMinusbool;

    void Awake()
    {
        formationGrid = GetComponent<Grid>();
        currentXPos = 0;
        currentYPos = 0;
        totalIndex = 1;
        currentIndex = 1;
        xPlusbool = false;
        xMinusbool = false;
        yPlusbool = false;
        yMinusbool = false;
    }


    public void PositionGrid()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, clickableLayer))
        {
            gameObject.transform.position = hit.point;
        }
    }

    public Vector3 MoveToBasicSquareFormation() //Use x and y for grid. Ignore z(for now)
    {
        //Calc spot on grid
        if (xPlusbool)//X+
        {
            currentXPos += 1;
        }
        else if (xMinusbool)//x-
        {
            currentXPos -= 1;
        }
        else if (yPlusbool)//y+
        {
            currentYPos += 1;
        }
        else if (yMinusbool)//Y-
        {
            currentYPos -= 1;
        }

        //Inciment the indexing
        if (currentIndex == totalIndex)
        {
            currentIndex = 1;

            //Switch bools
            if (xPlusbool)
            {
                xPlusbool = false;
                yMinusbool = true;
            }
            else if (yMinusbool)
            {
                yMinusbool = false;
                xMinusbool = true;
                totalIndex++;
            }
            else if (xMinusbool)
            {
                xMinusbool = false;
                yPlusbool = true;
            }
            else if (yPlusbool)
            {
                yPlusbool = false;
                xPlusbool = true;
                totalIndex++;
            }
            else
            {
                xPlusbool = true;
            }

        }
        else
        {
            currentIndex++; //Incriment Index
        }

        //Convert cell to world
        Vector3 worldPosition = formationGrid.CellToWorld(new Vector3Int(currentXPos, currentYPos, zPos));
        return worldPosition; //return
    }
}
