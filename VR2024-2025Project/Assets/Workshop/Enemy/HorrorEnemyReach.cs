using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorEnemyReach : MonoBehaviour
{
    public HorrorEnemy enemyControl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == enemyControl.target)
        {
            enemyControl.EnterReach(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == enemyControl.target)
        {
            enemyControl.EnterReach(false);
        }
    }
}
