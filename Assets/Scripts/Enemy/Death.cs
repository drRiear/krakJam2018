using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public EnemyType type;
    public bool isDead;
    public int amunition;

    private void Update()
    {
        if (isDead && amunition == 0)
            Destroy(gameObject);
        
    }

    private void TurnOffMovement()
    {
        switch (type)
        {
            case EnemyType.Patrol:
                GetComponent<EnemyPatrolBehaviour>().enabled = false;
                break;
            case EnemyType.Turret:

                break;
        }
    }

    public void Die()
    {
        isDead = true;
        TurnOffMovement();
    }

    public enum EnemyType { Patrol, Turret}
}
