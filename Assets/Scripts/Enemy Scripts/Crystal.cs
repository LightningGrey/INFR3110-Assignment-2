using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Enemy
{
    [SerializeField]
    private Subject subject;

    override public void Reset()
    {
        subject.Notify(QuestAction.Break);
        manager.GetEnemy();
        Destroy(gameObject);
    }
}

