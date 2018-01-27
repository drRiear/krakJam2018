using UnityEngine;
using System.Collections.Generic;

public class EnemyAndroidBehaviour : MonoBehaviour
{
    [SerializeField] private float distanceOfView;
    [SerializeField] private float speed;

    [SerializeField] private List<Transform> waypointsList;
    private List<Transform> waypointsQueueList;

    private State state;
    
    private void Start()
    {
        SetExeptions();

        SetupQueue();
    }
    private void Update()
    {
        switch (state)
        {
            case State.Patrol:
            Patrol();
                break;
        }
    }   
    
    #region Private Methods
    private void SetExeptions()
    {
        if (waypointsList.Count < 1)
            Debug.LogWarning("Waypoints not setted.");
    }
    private void Patrol()
    {
        if (waypointsQueueList.Count != 0)
            MoveToWaypoint();
        else
            ReverceQueue();
    }
    private void MoveToWaypoint()
    {
        var direction = waypointsQueueList[0].position - transform.position;

        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (Vector3Int.RoundToInt(transform.position) == Vector3Int.RoundToInt(waypointsQueueList[0].position))
            UnQueueWaypoint(waypointsQueueList[0]);
    }
    private void UnQueueWaypoint(Transform waypoint)
    {
        waypointsQueueList.Remove(waypoint);
    }
    private void SetupQueue()
    {
        waypointsQueueList = new List<Transform>(waypointsList);
    }
    private void ReverceQueue()
    {
        waypointsQueueList = new List<Transform>(waypointsList);
        waypointsQueueList.Reverse();
    }
    #endregion

    enum State { Patrol,  Idle, Pursuit, Fight}
}
