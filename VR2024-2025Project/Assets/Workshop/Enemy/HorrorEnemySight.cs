using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorEnemySight : MonoBehaviour
{
    public HorrorEnemy enemyControl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemyControl.target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == enemyControl.target)
        {
            enemyControl.target = null;
        }
    }
}
