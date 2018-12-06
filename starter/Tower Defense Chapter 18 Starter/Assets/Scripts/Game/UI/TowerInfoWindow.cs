using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfoWindow : MonoBehaviour {

    // reference to upgradable tower
    public Tower tower;
    
    public Text txtInfo;
    public Text txtUpgradeCost;
 
    private int upgradePrice;
  
    private GameObject btnUpgrade;

    // Finds upgrade button
    void Awake()
    {
        btnUpgrade = txtUpgradeCost.transform.parent.gameObject;
    }

    // call update info when window opens
    void OnEnable()
    {
        UpdateInfo();
    }

    // Calculate the price to upgrade the tower. Set the info text to reflect the tower’s level. If the tower level is less than three, show the upgrade button. If not, hide it.
    private void UpdateInfo()
    {
        // Calculate new price for upgrade
        upgradePrice = Mathf.CeilToInt(TowerManager.Instance.
        GetTowerPrice(tower.type) * 1.5f * tower.towerLevel);
        
        txtInfo.text = tower.type + " Tower Lv " + tower.towerLevel;
        
        if (tower.towerLevel < 3)
        {
            btnUpgrade.SetActive(true);
            txtUpgradeCost.text = "Upgrade\n" + upgradePrice + " Gold";
        }
        else
        {
            btnUpgrade.SetActive(false);
        }
    }
   
    public void UpgradeTower()
    {
        // checks if they have enough gold to upgrade tower 
        if (GameManager.Instance.gold >= upgradePrice)
        {
            GameManager.Instance.gold -= upgradePrice;
            tower.LevelUp();
            gameObject.SetActive(false);
        }
    }
}
