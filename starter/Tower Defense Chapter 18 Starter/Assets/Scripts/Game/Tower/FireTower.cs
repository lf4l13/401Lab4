using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower {

    // reference to fire particles which will be displayed on attack
    public GameObject fireParticlesPrefab;

    // Override the AttackEnemy() method from the Tower class to expand on it
    protected override void AttackEnemy()
    {
        // Call the Tower class AttackEnemy() method
        base.AttackEnemy();
        GameObject particles = (GameObject)Instantiate(fireParticlesPrefab,transform.position + new Vector3(0, .5f),fireParticlesPrefab.transform.rotation);

        // Change the particle range depending on this tower’s aggro radius
        // Scale fire particle radius with the aggro radius
        particles.transform.localScale *= aggroRadius / 10f;

        // Damage all enemies in this tower’s range. This is often referred to as an AOE (Area of Effect) attack in games
        foreach (Enemy enemy in EnemyManager.Instance.GetEnemiesInRange(
        transform.position, aggroRadius))
        {
            enemy.TakeDamage(attackPower);
        }
    }
}
