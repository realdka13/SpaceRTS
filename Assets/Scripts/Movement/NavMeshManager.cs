using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshManager : MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface surface;

    // Start is called before the first frame update
    void Awake()
    {
        UpdateNavMesh();
    }

    public void UpdateNavMesh()
    {
        surface.BuildNavMesh();
        Debug.Log("Nav Mesh Updated");
    }

}
