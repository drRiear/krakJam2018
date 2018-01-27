using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightController : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        GameController.isDetectedByEnemy = true;
    }

    void Update()
    {
        if (GameController.isDetectedByEnemy == true)
         Attack();
        
    }

    void Attack()
    {

    }
}
