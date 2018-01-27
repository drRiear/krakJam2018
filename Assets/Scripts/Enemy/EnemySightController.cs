using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightController : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        GameController.isDetected = true;
    }

    void Update()
    {
        if (GameController.isDetected == true)
         Attack();
        
    }

    void Attack()
    {

    }
}
