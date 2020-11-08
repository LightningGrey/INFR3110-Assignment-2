using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Enemy
{
    [SerializeField]
    private GameObject enemyTrigger;

    private void OnDestroy()
    {
        enemyTrigger.SetActive(true);
    }

}

