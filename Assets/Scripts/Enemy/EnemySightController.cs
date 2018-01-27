using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightController : MonoBehaviour
{
    #region Inspector Vars

    [SerializeField] private float speedMultiplier = 1;
    [SerializeField] private float alarmTime;

    #endregion

    #region Private Vars

    private bool isInAlarm;
    private float alarmTimer;

    private EnemyPatrolBehaviour patrolBeh;
    #endregion

    #region Unity Events
    private void Awake()
    {
        patrolBeh = GetComponent<EnemyPatrolBehaviour>();
        alarmTimer = alarmTime;
    }
    void Update()
    {
        if (GameController.isDetectedByEnemy && !isInAlarm)
            RaiseAlarm();

        if (!GameController.isDetectedByEnemy)
            ReleaseAlarm();
    }
    #endregion

    #region Private Methods

    private void RaiseAlarm()
    {
        alarmTimer = alarmTime;
        isInAlarm = true;
        patrolBeh.speed *= speedMultiplier;
    }

    private void ReleaseAlarm()
    {
        if (alarmTimer > 0)
            alarmTimer -= Time.deltaTime;
        else if (isInAlarm)
        {
            isInAlarm = false;
            patrolBeh.speed /= speedMultiplier;
        }
    }
    #endregion
}
