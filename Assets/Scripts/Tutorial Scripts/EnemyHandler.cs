using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    //max number of enemies in spawn
    public List<GameObject> enemies;
    //how many waves
    [SerializeField] private List<int> waves;
    //final trigger
    [SerializeField] private GameObject triggerableObject;

    // Start is called before the first frame update
    public void Call(GameObject enemy)
    {
        //remove enemy from list
        enemies.Remove(enemy);
        //
        if (enemies.Count <= 0)
        {
            //no more waves, activate last trigger
            if (waves.Count <= 0)
            {
                triggerableObject.SetActive(true);
            }
            else
            {
                for (int i = 0; i < waves[0]; i++)
                {
                    return;
                }
            }
        }
    }

}
