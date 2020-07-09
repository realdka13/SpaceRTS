using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationMarker : MonoBehaviour
{

    private float currentTime;
    private float startTime;
    private bool startTimeFound = false;
    private bool timerActive = false;
    private bool resetTimer = false;
    private int iconTime = 2;

    [SerializeField]
    private LayerMask clickableLayer;

    private void Start()
    {
        gameObject.SetActive(false); //Disable on Start
    }

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        currentTime = Time.time;
        //if time active and not measured already measure first time
        if (timerActive && !startTimeFound || resetTimer)
        {
            startTime = currentTime;
            startTimeFound = true;
            resetTimer = false;
        }
        //If time active measure time difference from start and compare to threshold
        if (timerActive && (currentTime - startTime) > iconTime)
        {
            gameObject.SetActive(false);
            timerActive = false;
            startTimeFound = false;
        }
    }

    public void SpawnMarker()
    {
        //Reset Timer To true if changing location before things despawms
        if (timerActive)
        {
            resetTimer = true;
        }

        //Move Marker To correct Location
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, clickableLayer))
        {
            gameObject.transform.position = hit.point;

            //Set Marker Active
            gameObject.SetActive(true);

            //Disable Marker After A few seconds
            timerActive = true;
        }
    }
}
