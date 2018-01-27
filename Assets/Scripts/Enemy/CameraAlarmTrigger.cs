﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAlarmTrigger : MonoBehaviour
{
    #region Inspector Vars

    [SerializeField] private float sceleMultiplier;
    [SerializeField] private float alarmTime;

    #endregion

    #region Private Vars

    private bool isBig;
    private float alarmTimer;

    private PolygonCollider2D polygonCollider;
    private LineRenderer vision;

    private CameraBehaviour behaviourComponent; 
    #endregion

    #region Unity Events
    private void Awake()
    {
        alarmTimer = alarmTime;

        behaviourComponent = GetComponentInParent<CameraBehaviour>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        vision = GetComponent<LineRenderer>();

        vision.positionCount = polygonCollider.points.Length;
        for (int i = 0; i < polygonCollider.points.Length; i++)
            vision.SetPosition(i, new Vector3(polygonCollider.points[i].x, polygonCollider.points[i].y, 0.0f));

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != CharacterManager.Instance.player) return;

        GameController.isDetectedByCamera = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject != CharacterManager.Instance.player) return;

        StartTimer();
    }
    void Update()
    {
        if (GameController.isDetectedByCamera)
            RaiseAlarm();
        
        if (!GameController.isDetectedByCamera)
            ReleaseAlarm();
    }
    #endregion

    #region Private Methods

    private void RaiseAlarm()
    {
        if (!isBig)
            transform.localScale *= sceleMultiplier;

        behaviourComponent.state = CameraBehaviour.State.LockOnPlayer;
        alarmTimer = alarmTime;
        isBig = true;
    }

    private void ReleaseAlarm()
    {
        if (alarmTimer > 0)
            alarmTimer -= Time.deltaTime;
        else if (isBig)
        {
            isBig = false;
            transform.localScale /= sceleMultiplier;
            behaviourComponent.state = CameraBehaviour.State.Rotating;
        }
    }

    private void StartTimer()
    {
        behaviourComponent.state = CameraBehaviour.State.Alarm;
        GameController.isDetectedByCamera = false;

    }
    #endregion
}
