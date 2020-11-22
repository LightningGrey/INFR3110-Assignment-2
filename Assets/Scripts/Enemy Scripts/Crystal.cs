using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Enemy
{

    override public void Reset()
    {
        manager.GetEnemy();
        Destroy(gameObject);
    }
}

