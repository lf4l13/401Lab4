using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager Instance;
    
    // list for enemies
    public List<Enemy> Enemies = new List<Enemy>();
    
    void Awake()
    {
        Instance = this;
    }
    
    // creates enemy health bar
    public void RegisterEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
        UIManager.Instance.CreateHealthBarForEnemy(enemy);

    }

    // removes unregistered enemy
    public void UnRegister(Enemy enemy)
    {
        Enemies.Remove(enemy);
    }
    
    // this is like a raycast for the enemies in range 
    public List<Enemy> GetEnemiesInRange(Vector3 position, float range)
    {
        return Enemies.Where(enemy => Vector3.Distance(position, enemy.transform.position) <= range).ToList();
    }

    // removes the enemy when they reach 0 health or escape
    public void DestroyAllEnemies()
    {
        foreach (Enemy enemy in Enemies)
        {
            Destroy(enemy.gameObject);
        }
        Enemies.Clear();
    }
}