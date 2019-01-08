using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Engineer : MonoBehaviour
{
    //The Objects Nav Mesh Agent
    NavMeshAgent nmAgent;

    //StatManager
    private UnitStatsManager statManager;

    void Start()
    {
        statManager = FindObjectOfType<UnitStatsManager>();
        nmAgent = GetComponent<NavMeshAgent>();
        IExist();

        //Update Stats
        nmAgent.speed = statManager.GetComponent<UnitStatsManager>().GetStat("engineer","speed");
    }

    //Method to tell Stats Unit that I exist or dont exist anymore
    private void IExist()
    {
        statManager.AddToList("engineer",this.gameObject);
    }
    private void ImGone()
    {
        statManager.RemoveFromList("engineer", this.gameObject);
    }

    //Method for when the Update all is called **Keep adding here as more stats get added***
    public void UpdateStats(int speed)
    {
        nmAgent.speed = speed;
    }
}
