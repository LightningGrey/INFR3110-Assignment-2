using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    [SerializeField]
    private int attackDamage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player was hit");
            other.GetComponent<PlayerMovement>().OnHit(attackDamage);
        }
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy was hit");
            other.GetComponent<Enemy>().OnHit(attackDamage);
        }
    }
}
