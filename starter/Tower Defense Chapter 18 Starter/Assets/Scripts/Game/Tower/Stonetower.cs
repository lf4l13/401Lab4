using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stonetower : Tower {

    // This is the projectile this (stone) tower will shoot
    public GameObject stonePrefab;
    
    // override AttackEnemy function and call base. AttackEnemy function so the class code gets executed first 
    protected override void AttackEnemy()
    {
        base.AttackEnemy();
        // spawn a new stone projectile
        GameObject stone = (GameObject)Instantiate(stonePrefab, towerPieceToAim.position, Quaternion.identity);
        stone.GetComponent<Stone>().enemyToFollow = targetEnemy;
        stone.GetComponent<Stone>().damage = attackPower;
    }
}