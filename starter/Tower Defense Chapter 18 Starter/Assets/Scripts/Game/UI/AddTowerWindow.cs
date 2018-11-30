using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class AddTowerWindow : MonoBehaviour {

    public GameObject towerSlotToAddTowerTo;
    //2
    public void AddTower(string towerTypeAsString)
    {
        //3
        Tower.TowerType type = (Tower.TowerType)Enum.Parse(typeof(Tower.TowerType),
        towerTypeAsString, true);
        //4
        if (TowerManager.Instance.GetTowerPrice(type) <=
        GameManager.Instance.gold)
        {
            //5
            GameManager.Instance.gold -= TowerManager.Instance
            .GetTowerPrice(type);
            //6
            TowerManager.Instance.CreateNewTower(towerSlotToAddTowerTo, type);
            gameObject.SetActive(false);
        }
    }
}
