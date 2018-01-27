using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAlarmTrigger : MonoBehaviour
{
    #region Inspector Vars

    [SerializeField] private float sceleMultiplier;
    [SerializeField] private float alarmTime;

    #endregion

    #region Private Vars

    private bool isInAlarm;
    private float alarmTimer;

    private PolygonCollider2D polygonCollider;
    private LineRenderer vision;
    #endregion

    #region Unity Events
    private void Awake()
    {
        alarmTimer = alarmTime;


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
        if (GameController.isDetectedByCamera && !isInAlarm)
            RaiseAlarm();
        

        if (!GameController.isDetectedByCamera)
            ReleaseAlarm();
    }
    #endregion

    #region Private Methods

    private void RaiseAlarm()
    {
        alarmTimer = alarmTime;
        isInAlarm = true;
        transform.localScale *= sceleMultiplier;
    }

    private void ReleaseAlarm()
    {
        if (alarmTimer > 0)
            alarmTimer -= Time.deltaTime;
        else if (isInAlarm)
        {
            isInAlarm = false;
            transform.localScale /= sceleMultiplier;
        }
    }

    private void StartTimer()
    {
        GameController.isDetectedByCamera = false;
        
    }
    #endregion
}
