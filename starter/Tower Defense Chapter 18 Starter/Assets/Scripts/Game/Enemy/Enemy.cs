﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public float moveSpeed = 3f;
    public int goldDrop = 10;

    public int pathIndex = 0;

    private int wayPointIndex = 0;

    void Start()
    {
        EnemyManager.Instance.RegisterEnemy(this);
    }
    void OnGotToLastWayPoint()
    {
        Die();
    }

    public void TakeDamage(float amountOfDamage)
    {
        health -= amountOfDamage;

        if (health <= 0)
        {
            DropGold();
            Die();
        }
    }

    void DropGold()
    {
        GameManager.Instance.gold += goldDrop;
    }

    void Die()
    {
        if (gameObject != null)
        {
            EnemyManager.Instance.UnRegister(this);
            
            gameObject.AddComponent<AutoScaler>().scaleSpeed = -2;
            
            enabled = false;
            Destroy(gameObject, 0.3f);
        }
    }

    void Update()
    {
        // Update movement
        if (wayPointIndex < WayPointManager.Instance.Paths[pathIndex].WayPoints.Count)
        {
            UpdateMovement();
        }
        else
        { // call on last waypoint
            OnGotToLastWayPoint();
        }
    }
    private void UpdateMovement()
    {
        // next waypoint is the target position
        Vector3 targetPosition =  WayPointManager.Instance.Paths[pathIndex].WayPoints[wayPointIndex].position;
        // moves toward target 
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // look at the target
        transform.localRotation = UtilityMethods.SmoothlyLook(transform, targetPosition);
        // if enemy is close to waypoint set the next waypont as the target.
        if (Vector3.Distance(transform.position, targetPosition) < .1f)
        {
            wayPointIndex++;
        }
    }
}
