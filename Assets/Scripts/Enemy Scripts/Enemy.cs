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

    void Start()
    {
        maxHP = HP;
        originalPos = transform.position;
        originalRot = transform.rotation;
    }

    public void OnHit(int damage)
    {
        HP -= damage;
        healthBar.SetHealth(HP);
        if (HP <= 0)
        {
            Reset();
        }
    }

    virtual public void Reset()
    {
    }

}
