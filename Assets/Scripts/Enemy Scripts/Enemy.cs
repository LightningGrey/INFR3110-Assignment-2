using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    protected int maxHP;
    public HealthBar healthBar;

    public EnemyPool manager;
    protected Vector3 originalPos;
    protected Quaternion originalRot;

    private StatsLogger _stats;

    void Start()
    {
        maxHP = HP;
        originalPos = transform.position;
        originalRot = transform.rotation;
        _stats = GameObject.FindGameObjectWithTag("Logger").GetComponent<StatsLogger>();

    }

    public void OnHit(int damage)
    {
        HP -= damage;
        healthBar.SetHealth(HP);
        if (HP <= 0)
        {
            _stats.OnEnemyKill();
            Reset();
        }
    }

    virtual public void Reset()
    {
    }

}
