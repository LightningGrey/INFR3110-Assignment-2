using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemy;
    private GameObject _enemyClone;
    [SerializeField]
    private int _maxEnemies = 3;

    private Queue<GameObject> _enemyPool;

    // Start is called before the first frame update
    void Start()
    {
        _enemyPool = new Queue<GameObject>();
        _BuildEnemyPool();
    }

    private void _BuildEnemyPool()
    {
        for (int i = 0; i < _maxEnemies; i++)
        {
            _enemyClone = Instantiate(enemy);
            _enemyClone.SetActive(false);
            _enemyPool.Enqueue(_enemyClone);
        }
    }

    public GameObject GetEnemy()
    {
        if (!IsEmpty())
        {
            enemy = _enemyPool.Dequeue();
        } else
        {
            _enemyPool.Enqueue(Instantiate(enemy));
        }
        enemy.SetActive(true);
        return enemy;
    }

    public void ResetEnemy(GameObject _enemy)
    {
        _enemy.SetActive(false);
        _enemyPool.Enqueue(_enemy);
    }

    public bool IsEmpty()
    {
        return (_enemyPool.Count <= 0);
    }

}
