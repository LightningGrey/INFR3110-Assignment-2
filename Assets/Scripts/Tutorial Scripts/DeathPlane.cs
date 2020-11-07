using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject checkpoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = checkpoint.transform.position;
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
