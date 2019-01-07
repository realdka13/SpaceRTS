using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshManager : MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface surface;

    // Start is called before the first frame update
    void Start()
    {
        UpdateNavMesh();
    }

    public void UpdateNavMesh()
    {
        surface.BuildNavMesh();
        print("Nav Mesh Updated");
    }

}
