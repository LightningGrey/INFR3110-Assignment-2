using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    public HealthBar healthBar;

    public EnemyHandler manager;

    void Start()
    {
       
    }

    public void OnHit(int damage)
    {
        HP -= damage;
        healthBar.SetHealth(HP);
        if (HP <= 0)
        {
            manager.Call(gameObject);
            Destroy(gameObject);
        }
    }

}
