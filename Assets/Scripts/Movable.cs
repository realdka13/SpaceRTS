using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private LayerMask clickableLayer;

    public void ListenForMovementCommand()
    {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, clickableLayer))
            {
                agent.SetDestination(hit.point);
            }
            else
            {
                Debug.LogWarning("RayCast Failed");
            }
    }
}