using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Panels
    [SerializeField]
    private GameObject engineerBuildingPanel;
    [SerializeField]
    private GameObject militaryUnitOptionsPanel;
    [SerializeField]
    private GameObject buildingOptionsPanel;


    // Start is called before the first frame update
    void Start()
    {
        //Set All panels to inactive  
        engineerBuildingPanel.SetActive(false);
        militaryUnitOptionsPanel.SetActive(false);
        buildingOptionsPanel.SetActive(false);
    }
}
