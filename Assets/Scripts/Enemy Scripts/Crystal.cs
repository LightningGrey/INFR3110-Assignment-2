using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Enemy
{
    [SerializeField]
    private EnemyPool enemyTrigger;
    [SerializeField]
    private Subject subject;

    override public void Reset()
    {
        enemyTrigger.GetEnemy();
        subject.Notify(QuestAction.Break);
        Destroy(gameObject);
    }
}

