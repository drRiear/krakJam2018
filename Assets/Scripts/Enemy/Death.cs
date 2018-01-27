using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    public bool isDead;

    public int amunition;

    private void Update()
    {
        if (isDead && amunition == 0)
            Destroy(gameObject);

        if (isDead)
            GetComponent<EnemyPatrolBehaviour>().enabled = false;
    }
}
