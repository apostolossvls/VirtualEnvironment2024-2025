using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorEnemyAttack : MonoBehaviour
{
    public float damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInParent<PlayerHealth>()?.TakeDamage(damage);
        }
    }
}
