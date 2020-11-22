using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    [SerializeField]
    private int attackDamage;
    [SerializeField]
    private StatsLogger _stats;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().OnHit(attackDamage);
        }
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().OnHit(attackDamage);
            if (_stats) {
                _stats.OnHit();
            }
        }
    }
}
