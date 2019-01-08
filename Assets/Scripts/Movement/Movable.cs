using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Movable : MonoBehaviour
{

    private Vector3 targetLocation;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private LayerMask clickableLayer;

    public void MoveUnitToLocation(Grid grid)
    {
        targetLocation = grid.GetComponent<FormationGrid>().MoveToBasicSquareFormation();
        agent.SetDestination(targetLocation);
    }
}