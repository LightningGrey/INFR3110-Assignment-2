using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private DeathPlane _plane;
    private static float timeRemaining = 0.0f;
    private void CheckpointText()
    {
        timeRemaining = 3.0f;
        Debug.Log("Checkpoint");

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CheckpointText();
            _plane.SetCheckpoint(gameObject);
            
        }
    }
    private void Update()
    {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                Debug.Log(timeRemaining);
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


