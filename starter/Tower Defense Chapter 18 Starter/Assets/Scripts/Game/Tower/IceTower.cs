using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower {

    public GameObject icePrefab;

<<<<<<< HEAD
    // This makes sure the Ice Tower always has a target enemy
=======
>>>>>>> 4dd3aa56b99b082515fb621cd00c4b2dd96ddfff
    public override void Update()
    {
        base.Update();
        GetNonFrozenTarget();
    }

    private void GetNonFrozenTarget()
    {
<<<<<<< HEAD
        // checks for enemies in range
        foreach (Enemy enemy in GetEnemiesInAggroRange())
        {
            // and if they are not already frozen if true it freezes them 
=======
        foreach (Enemy enemy in GetEnemiesInAggroRange())
        {
>>>>>>> 4dd3aa56b99b082515fb621cd00c4b2dd96ddfff
            if (!enemy.frozen)
            {
                targetEnemy = enemy;
                break;
            }
        }
    }
<<<<<<< HEAD
    // Override Tower’s AttackEnemy() method then add custom functionality
    protected override void AttackEnemy()
    {
        base.AttackEnemy();
        // Create a new ice projectile and set its enemy to follow to the target enemy
=======
    protected override void AttackEnemy()
    {
        base.AttackEnemy();
        
>>>>>>> 4dd3aa56b99b082515fb621cd00c4b2dd96ddfff
        GameObject ice = (GameObject)Instantiate(icePrefab, towerPieceToAim.position, Quaternion.identity);
        ice.GetComponent<Followingprojectile>().enemyToFollow = targetEnemy;
    }
}