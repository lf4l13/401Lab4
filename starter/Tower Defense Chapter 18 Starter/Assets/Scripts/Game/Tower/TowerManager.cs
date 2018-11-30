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

public class TowerManager : MonoBehaviour {

    public static TowerManager Instance;
    //2
    public GameObject stoneTowerPrefab;
    public GameObject fireTowerPrefab;
    public GameObject iceTowerPrefab;
    //3
    public List<TowerCost> TowerCosts = new List<TowerCost>();
    //4
    void Awake()
    {
        Instance = this;
    }
    //5
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
    //6
    public int GetTowerPrice(Tower.TowerType towerType)
    {
        return (from towerCost in TowerCosts
                where towerCost.TowerType
                == towerType
                select towerCost.Cost).FirstOrDefault();
    }
}
