using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public struct TowerCost
{
    public Tower.TowerType TowerType;
    public int Cost;
}

public class TowerManager : MonoBehaviour
{

    // singleton static ref to this script is stored in Instance
    public static TowerManager Instance;
    // reference to the tower prefabs for spawning multiple towers 
    public GameObject stoneTowerPrefab;
    public GameObject fireTowerPrefab;
    public GameObject iceTowerPrefab;
    // stores the tower prices
    public List<TowerCost> TowerCosts = new List<TowerCost>();
    // sets instance to this script
    void Awake()
    {
        Instance = this;
    }
    // allows the tower slot and a type of tower as parameters & create a new copy of the certian tower at the certian slot selected. 
    // It also then disables the tower slot so only one tower can be there
    public void CreateNewTower(GameObject slotToFill, Tower.TowerType towerType)
    {
        switch (towerType)
        {
            case Tower.TowerType.Stone:
                Instantiate(stoneTowerPrefab, slotToFill.transform.position,
                Quaternion.identity);
                slotToFill.gameObject.SetActive(false);
                break;
            case Tower.TowerType.Fire:
                Instantiate(fireTowerPrefab, slotToFill.transform.position,
                Quaternion.identity);
                slotToFill.gameObject.SetActive(false);
                break;
            case Tower.TowerType.Ice:
                Instantiate(iceTowerPrefab, slotToFill.transform.position,
                Quaternion.identity);
                slotToFill.gameObject.SetActive(false);
                break;
        }
    }
    // This is a LINQ utility method to get the price of each certian tower type
    public int GetTowerPrice(Tower.TowerType towerType)
    {
        return (from towerCost in TowerCosts
                where towerCost.TowerType
                == towerType
                select towerCost.Cost).FirstOrDefault();
    }
}
