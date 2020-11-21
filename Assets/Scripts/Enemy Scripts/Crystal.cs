using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Enemy
{
    [SerializeField]
    private EnemyPool enemyTrigger;

    override public void Reset()
    {
        enemyTrigger.GetEnemy();
        Destroy(gameObject);
    }
}

