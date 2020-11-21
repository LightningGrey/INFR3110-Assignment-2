using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemy;
    private GameObject _enemyClone;
    [SerializeField]
    private int _maxEnemies = 3;
    public List<Vector3> _offsets;

    private Queue<GameObject> _enemyPool;
    [SerializeField]
    private EnemyHandler _manager;

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
        _manager.enemies.Add(enemy);
        enemy.SetActive(true);
        return enemy;           
    }

    public void ResetEnemy(GameObject _enemy)
    {
        _enemy.SetActive(false);
        _enemyPool.Enqueue(_enemy);
        _manager.Call(_enemy);

        //new spawn wave
        if (_manager.enemies.Count <= 0)
        {
            if (_manager.waves.Count > 0)
            {
                for (int i = 0; i < _manager.waves[0]; i++)
                {
                    GameObject newEnemy;
                    if (i >= 1)
                    {
                        newEnemy = GetEnemy();
                        newEnemy.transform.position += _offsets[i - 1];
                    } else
                    {
                        newEnemy = GetEnemy();
                    }
                }
                _manager.waves.RemoveAt(0);
            }
        }

    }

    public bool IsEmpty()
    {
        return (_enemyPool.Count <= 0);
    }

}
