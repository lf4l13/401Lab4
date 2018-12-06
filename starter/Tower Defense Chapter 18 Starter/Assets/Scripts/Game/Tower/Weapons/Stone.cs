using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Followingprojectile
{

    // The amount of damage that gets inflicted to the enemy on impact
    public float damage;

    // Override Followingprojectile’s OnHitEnemy() method
    protected override void OnHitEnemy()
    {
        // deal damage to enemy and destroy projectile
        enemyToFollow.TakeDamage(damage);
        Destroy(gameObject);
    }
}