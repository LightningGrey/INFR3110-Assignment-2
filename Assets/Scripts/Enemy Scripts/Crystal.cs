using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Enemy
{
    [SerializeField]
    private GameObject enemyTrigger;

    public void OnDestroy()
    {
        enemyTrigger.SetActive(true);
    }

}

