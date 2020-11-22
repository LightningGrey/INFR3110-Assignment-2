using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    //max number of enemies in spawn
    public List<GameObject> enemies;
    //how many waves
    public List<int> waves;
    //final trigger
    [SerializeField] private GameObject triggerableObject;
    [SerializeField] private Subject subject;

    // Start is called before the first frame update
    public void Call(GameObject enemy)
    {
        //remove enemy from list
        enemies.Remove(enemy);

        if (enemies.Count <= 0)
        {
            //no more waves, activate last trigger
            if (waves.Count <= 0)
            {
                subject.Notify(QuestAction.Defeat);
                triggerableObject.SetActive(true);
            }
        }
    }

}
