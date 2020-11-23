using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private StatsLogger _stats;
    private float lastTime = 0.0f;
    [SerializeField] private Checkpoint previousPoint;
    [SerializeField]
    private Subject subject;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float currentTime = Time.time;
            float checkpointTime = currentTime - previousPoint.currentTime;
            _stats.OnCheckpoint(checkpointTime);
            _stats.SaveStats();

            subject.Notify(QuestAction.Leave);
            SceneManager.LoadScene(0);
        }
    }

}
