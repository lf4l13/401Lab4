using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Followingprojectile {

<<<<<<< HEAD
    // This method overrides FollowingProjectile and adds its own logic. When the ice projectile hits the enemy, the enemy should freeze and the projectile destroys itself
=======
>>>>>>> 4dd3aa56b99b082515fb621cd00c4b2dd96ddfff
    protected override void OnHitEnemy()
    {
        enemyToFollow.Freeze();
        Destroy(gameObject);
    }

}