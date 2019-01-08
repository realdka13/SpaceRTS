using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandCenter : MonoBehaviour
{

    [SerializeField]
    private GameObject commandCenterUI;
    [SerializeField]
    private GameObject selectedIcon;

    // Start is called before the first frame update
    void Start()
    {
        //Set Icon to Off by default
        selectedIcon.SetActive(false);
    }

}
