using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSightController : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        GameController.isDetectedByCamera = true;
    }

    void Update()
    {
        if (GameController.isDetectedByCamera == true)
            RaiseAlarm();
    }

    void RaiseAlarm()
    {
    }
}
