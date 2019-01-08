using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatsManager : MonoBehaviour
{
    PlayerOneUnits.EngineerStats playerEnginStats;

    [SerializeField]
    private List<GameObject> engineers;

    //Updates all stats at the start
    private void Awake()
    {
        playerEnginStats = new PlayerOneUnits.EngineerStats
        {
            //Init Stats
            Speed = 15
        };
    }

    //The method for returning stats
    public int GetStat(string unit, string stat)
    {
        if (unit == "engineer")
        {
            if (stat == "speed")
            {
                return playerEnginStats.Speed;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    //Update Stats of All Units **Keep adding here as more stats are added**
    public void UpdateAllStats()
    {
        foreach (GameObject engin in engineers)
        {
            engin.GetComponent<Engineer>().UpdateStats(playerEnginStats.Speed);
            print("Speed Updated");
        }
    }

    //Deal With Unit Lists
    public void AddToList(string unitName, GameObject unit)
    {
        if (unitName == "engineer")
        {
            engineers.Add(unit);
        }
    }
    public void RemoveFromList(string unitName, GameObject unit)
    {
        if (unitName == "engineer")
        {
            engineers.Remove(unit);
        }
    }
}
