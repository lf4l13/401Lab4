using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Followingprojectile : MonoBehaviour
{
    // enemy to be followed
    public Enemy enemyToFollow;
    
    public float moveSpeed = 15;
    private void Update()
    {
        // If the enemy this projectile is following doesn’t exist anymore, it should destroy itself
        if (enemyToFollow == null)
        {
            Destroy(gameObject);
        }
        else
        { 
            transform.LookAt(enemyToFollow.transform);
            GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;
        }
    }

    // If this projectile hits an object, and it’s the enemy it’s following, then call OnHitEnemy function
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() == enemyToFollow)
        {
            OnHitEnemy();
        }
    }
    protected abstract void OnHitEnemy();
   
}