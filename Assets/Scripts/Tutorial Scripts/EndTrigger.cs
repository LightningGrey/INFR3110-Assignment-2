using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private StatsLogger _stats;
    private float lastTime = 0.0f;
    [SerializeField] private Checkpoint previousPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float currentTime = Time.time;
            float checkpointTime = currentTime - previousPoint.currentTime;
            _stats.OnCheckpoint(checkpointTime);
            _stats.SaveStats();

            SceneManager.LoadScene(0);
        }
    }

}
