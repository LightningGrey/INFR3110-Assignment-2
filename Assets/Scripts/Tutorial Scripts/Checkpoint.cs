using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private DeathPlane _plane;
    //TODO: make this non-static
    private static float timeRemaining = 0.0f;

    //log checkpoint times
    [SerializeField] private bool isActivated = false;
    [SerializeField] private StatsLogger _stats;
    public float currentTime;
    [SerializeField] private Checkpoint previousPoint;


    public void Awake()
    {
        currentTime = Time.time;
    }

    private void CheckpointText()
    {
        timeRemaining = 3.0f;
        //Debug.Log("Checkpoint");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isActivated)
        {
            CheckpointText();
            _plane.SetCheckpoint(gameObject);

            float currentTime = Time.time;
            float checkpointTime;
            if (previousPoint)
            {
                checkpointTime = currentTime - previousPoint.currentTime;
            }
            else
            {
                checkpointTime = currentTime - 0.0f;
            }
            //send checkpoint time to next checkpoint
            _stats.OnCheckpoint(checkpointTime);
            isActivated = true;
            
        }
    }
    private void Update()
    {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

               // Debug.Log(timeRemaining);
            }


            Text CheckpHitText = GameObject.Find("Player HUD/Checkpoint_Text").GetComponent<Text>();

            if (timeRemaining > 0)
            {
                CheckpHitText.text = "Checkpoint Hit";
            }
            else
            {
                CheckpHitText.text = "";
            }

    }

}


