using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSightController : MonoBehaviour
{
    [SerializeField]private Transform target1 = default(Transform);

    void OnTriggerEnter2D(Collider2D other)
    {
        GameController.isDetectedByCamera = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameController.isDetectedByCamera = false;
    }

    void Update()
    {
        if (GameController.isDetectedByCamera == true)
        {
            RaiseAlarm();
        }
            
    }

    void RaiseAlarm()
    {
            float distance = Vector2.Distance(target1.position, transform.position);
            if (distance < 10) // <
            {
                Vector2 dir = transform.position - target1.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion qto = Quaternion.AngleAxis(angle, Vector3.forward);
                Quaternion qto2 = Quaternion.Euler(qto.eulerAngles.x,
                                                    qto.eulerAngles.y,
                                                    qto.eulerAngles.z - 90);

                transform.rotation = (Quaternion.Slerp(transform.rotation, qto2, 5f * Time.deltaTime));
            }

    }
}

