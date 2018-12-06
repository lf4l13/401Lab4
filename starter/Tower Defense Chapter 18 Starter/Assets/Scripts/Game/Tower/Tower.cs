using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public float attackPower = 3f;
    
    public float timeBetweenAttacksInSeconds = 1f;
    
    public float aggroRadius = 15f;
    
    public int towerLevel = 1;
    
    public TowerType type;
    
    public AudioClip shootSound;
    
    public Transform towerPieceToAim;
    
    public Enemy targetEnemy = null;
    
    private float attackCounter;

    // enum for the stone, fire and ice tower types 
    public enum TowerType
    {
        Stone, Fire, Ice
    }

    // alllows the tower to smoothly look at it's target 
    private void SmoothlyLookAtTarget(Vector3 target)
    {
        towerPieceToAim.localRotation = UtilityMethods.
        SmoothlyLook(towerPieceToAim, target);
    }

    // plays the shoot sound when tower fires 
    protected virtual void AttackEnemy()
    {
        GetComponent<AudioSource>().PlayOneShot(shootSound, .15f);
    }

    // gets enemies in aggro range
    public List<Enemy> GetEnemiesInAggroRange()
    {
        List<Enemy> enemiesInRange = new List<Enemy>();
        // adds the ene,ies that are within range to the enemiesInRange list 
        foreach (Enemy enemy in EnemyManager.Instance.Enemies)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position)
            <= aggroRadius)
            {
                enemiesInRange.Add(enemy);
            }
        }
        // Returns to the list 
        return enemiesInRange;
    }
    // detects the enemy closest to the tower
    public Enemy GetNearestEnemyInRange()
    {
        Enemy nearestEnemy = null;
        float smallestDistance = float.PositiveInfinity;
        // when the whole enemy list is iterated the nearestenemy will be the closest one
        foreach (Enemy enemy in GetEnemiesInAggroRange())
        {
            if (Vector3.Distance(transform.position, enemy.transform.position)
            < smallestDistance)
            {
                smallestDistance = Vector3.Distance(transform.position,
                enemy.transform.position);
                nearestEnemy = enemy;
            }
        }
        // Return the nearest enemy
        return nearestEnemy;
    }

    public virtual void Update()
    {
        // Decrement the attackCounter.
        attackCounter -= Time.deltaTime;
        // checks if no enemy is currently targeted
        if (targetEnemy == null)
        {
            // If there’s a Transform to rotate, look at a neutral position. This is the tower’s idle state
            if (towerPieceToAim)
            {
                SmoothlyLookAtTarget(towerPieceToAim.transform.position -
                new Vector3(0, 0, 1));
            }
            // finds the new target enemy
            if (GetNearestEnemyInRange() != null
            && Vector3.Distance(transform.position,
            GetNearestEnemyInRange().transform.position)
            <= aggroRadius)
            {
                targetEnemy = GetNearestEnemyInRange();
            }
        }
        else
        {
            // checks if there is a target enemy assigned. If so, look at the target enemy
            if (towerPieceToAim)
            {
                SmoothlyLookAtTarget(targetEnemy.transform.position);
            }
            // calls attack enemy when equal to or below 0 attackCounter and reset counter
            if (attackCounter <= 0f)
            {
                // Attack
                AttackEnemy();
                // Reset attack counter
                attackCounter = timeBetweenAttacksInSeconds;
            }
            // if enemy moves out of aggro range set targetEnemy to nothing.
            if (Vector3.Distance(transform.position,
            targetEnemy.transform.position) > aggroRadius)
            {
                targetEnemy = null;
            }
        }
    }

    public void LevelUp()
    {
        towerLevel++;
        //Calculate new stats for this tower
        attackPower *= 2;
        timeBetweenAttacksInSeconds *= 0.7f;
        aggroRadius *= 1.20f;
    }

    // shows the tower info for upgrading towers 
    public void ShowTowerInfo()
    {
        UIManager.Instance.ShowTowerInfoWindow(this);
    }
       
}