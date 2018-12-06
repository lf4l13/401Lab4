using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Followingprojectile {

    // This method overrides FollowingProjectile and adds its own logic. When the ice projectile hits the enemy, the enemy should freeze and the projectile destroys itself
    protected override void OnHitEnemy()
    {
        enemyToFollow.Freeze();
        Destroy(gameObject);
    }

}