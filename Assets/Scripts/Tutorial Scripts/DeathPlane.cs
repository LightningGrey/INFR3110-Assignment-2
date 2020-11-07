using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject checkpoint;

    void OnCollisionEnter(Collision other)
    {
        other.transform.position = checkpoint.transform.position;
    }
}
