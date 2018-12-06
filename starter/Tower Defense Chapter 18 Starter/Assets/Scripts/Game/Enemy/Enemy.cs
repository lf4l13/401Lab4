using UnityEngine;

public class Enemy : MonoBehaviour
{
    // variables for enemies such as their health, speed, gold drop and the affect the ice tower has on them
    public float maxHealth = 100f;
    public float health = 100f;
    public float moveSpeed = 3f;
    public int goldDrop = 10;
    public float timeEnemyStaysFrozenInSeconds = 2f;
    public bool frozen;
    private float freezeTimer;

    // beginning of the path 
    public int pathIndex = 0;

    // waypoints to follow
    private int wayPointIndex = 0;

    // registers enemy 
    void Start()
    {
        EnemyManager.Instance.RegisterEnemy(this);
    }

    // ensures they despawn when reaching the last waypoint
    void OnGotToLastWayPoint()
    {
        Die();
    }

    // allows the enemies to take damage 
    public void TakeDamage(float amountOfDamage)
    {
        health -= amountOfDamage;

        if (health <= 0)
        {
            DropGold();
            Die();
        }
    }

    // makes sure the enemies drop gold after dying
    void DropGold()
    {
        GameManager.Instance.gold += goldDrop;
    }

    // destroys enemies when killed by tower and unregisters them 
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

<<<<<<< HEAD
    // this is used to ensure the ice tower works on the enemies 
=======
>>>>>>> 4dd3aa56b99b082515fb621cd00c4b2dd96ddfff
    public void Freeze()
    {
        if (!frozen)
        {
<<<<<<< HEAD
            // checks if the enemy is frozen if so slow down speed
=======
            //2
>>>>>>> 4dd3aa56b99b082515fb621cd00c4b2dd96ddfff
            frozen = true;
            moveSpeed /= 2;
        }
    }
<<<<<<< HEAD
    // checks if the enemy was previously frozen then when the freeze timer wears off the enemies speed increases back to normal
=======
    //3
>>>>>>> 4dd3aa56b99b082515fb621cd00c4b2dd96ddfff
    void Defrost()
    {
        freezeTimer = 0f;
        frozen = false;
        moveSpeed *= 2;
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
        if (frozen)
        {
<<<<<<< HEAD
            
            freezeTimer += Time.deltaTime;
            // checks if the enemy was previously frozen
=======
            //2
            freezeTimer += Time.deltaTime;
            //3
>>>>>>> 4dd3aa56b99b082515fb621cd00c4b2dd96ddfff
            if (freezeTimer >= timeEnemyStaysFrozenInSeconds)
            {
                Defrost();
            }
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
