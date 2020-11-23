using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject _checkpoint;
    [SerializeField]
    private GameObject _follow;
    [SerializeField]
    private StatsLogger _stats;

    public void SetCheckpoint(GameObject p_checkpoint)
    {
        _checkpoint = p_checkpoint;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = _checkpoint.transform.position;
            other.GetComponent<PlayerMovement>().ResetRotations();
            other.GetComponent<PlayerMovement>().ResetHealth();
            other.GetComponent<CharacterController>().enabled = true;
            _stats.OnDeath();
        }
    }
}
