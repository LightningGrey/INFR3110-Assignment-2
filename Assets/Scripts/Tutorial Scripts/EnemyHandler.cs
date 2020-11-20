using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private GameObject triggerableObject;

    // Start is called before the first frame update
    public void Call(GameObject enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count <= 0)
        {
            triggerableObject.SetActive(true);
        }
    }

}
