using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower {

    public GameObject icePrefab;

    // This makes sure the Ice Tower always has a target enemy
    public override void Update()
    {
        base.Update();
        GetNonFrozenTarget();
    }

    private void GetNonFrozenTarget()
    {
        // checks for enemies in range
        foreach (Enemy enemy in GetEnemiesInAggroRange())
        {
            // and if they are not already frozen if true it freezes them 
            if (!enemy.frozen)
            {
                targetEnemy = enemy;
                break;
            }
        }
    }
    // Override Tower’s AttackEnemy() method then add custom functionality
    protected override void AttackEnemy()
    {
        base.AttackEnemy();
        // Create a new ice projectile and set its enemy to follow to the target enemy
        GameObject ice = (GameObject)Instantiate(icePrefab, towerPieceToAim.position, Quaternion.identity);
        ice.GetComponent<Followingprojectile>().enemyToFollow = targetEnemy;
    }
}