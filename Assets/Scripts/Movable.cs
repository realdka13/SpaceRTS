using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField]
    public NavMeshAgent agent;

    public void ListenForMovementCommand()
    {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
            }
            else
            {
                Debug.LogWarning("RayCast Failed");
            }
    }
}