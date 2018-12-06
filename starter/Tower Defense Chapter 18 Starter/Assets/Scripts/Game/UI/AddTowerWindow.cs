using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class AddTowerWindow : MonoBehaviour
{
    // The reference to the tower slot where the tower should be built
    public GameObject towerSlotToAddTowerTo;
    // The AddTower() method takes a single string parameter: The tower’s type
    public void AddTower(string towerTypeAsString)
    {
        // Convert the string parameter that was passed into the TowerType enum, due to the fact that enums aren't supported for trigger events
        Tower.TowerType type = (Tower.TowerType)Enum.Parse(typeof(Tower.TowerType),
        towerTypeAsString, true);
        // Check that the player has enough gold to afford the chosen tower
        if (TowerManager.Instance.GetTowerPrice(type) <=
        GameManager.Instance.gold)
        {
            // Subtract the tower’s price from the player’s gold
            GameManager.Instance.gold -= TowerManager.Instance.GetTowerPrice(type);
            // Call CreateNewTower() on the TowerManager and disable the AddTowerWindow
            TowerManager.Instance.CreateNewTower(towerSlotToAddTowerTo, type);
            gameObject.SetActive(false);
        }
    }
}
