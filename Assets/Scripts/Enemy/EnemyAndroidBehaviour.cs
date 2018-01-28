using UnityEngine;
using System.Collections.Generic;

public class EnemyAndroidBehaviour : MonoBehaviour
{
    [SerializeField] private float distanceOfView;
    [SerializeField] private float speed;
    [SerializeField] private float inIdleTime;
    [SerializeField] private List<AudioClip> clips;


    [SerializeField] private List<Transform> waypointsList;
    private List<Transform> waypointsQueueList;

    private Transform lastWaypoint;
    private float timer;
    private State state;
    private Vector3 direction;
    private AudioSource audioSource;
    private bool clipPlayed;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawRay(transform.position, direction.normalized * distanceOfView);
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        timer = inIdleTime;

        waypointsQueueList = new List<Transform>(waypointsList);

        SetExeptions();

        SetupQueue();
    }
    private void Update()
    {
        switch (state)
        {
            case State.Patrol:
                LookForPlayer();
                Patrol();
                break;
            case State.Idle:
                LookForPlayer();
                Idle();
                break;
            case State.Pursuit:

                if (!clipPlayed)
                {
                    clipPlayed = true;  

                    var index = Random.Range(0, clips.Count);
                    audioSource.clip = clips[index];
                    audioSource.Play();
                }

                Pursuit();  
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int wallLayer = (1 << CharacterManager.Instance.wallsLayer.value) + 7;
        if (collision.gameObject.layer == wallLayer && state == State.Pursuit)
            state = State.Idle;

        var deathComponent = collision.gameObject.GetComponent<PlayerDeath>();

        if (deathComponent == null) return;

        deathComponent.Die();
    }

    #region Private Methods
    private void SetExeptions()
    {
        if (waypointsList.Count < 1)
            Debug.LogWarning("Waypoints not setted.");
    }

    private void LookForPlayer()
    {
        var hits = Physics2D.RaycastAll(transform.position, direction.normalized, distanceOfView);

        foreach(var hit in hits)
        {
            if (hit.collider.gameObject.layer == 8)
                return;
            if (hit.collider.gameObject == CharacterManager.Instance.player)
                state = State.Pursuit;
        }
    }

    #region State Methods

    private void Patrol()
    {
        timer = inIdleTime;

        SetLastWaypoint();

        if (waypointsQueueList.Count == 0)
        {
            state = State.Idle;
            SetupQueue();
        }
        else
            MoveToWaypoint();
    }
    private void Idle()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
            state = State.Patrol;
    }

    private void Pursuit()
    {
        Transform playerTransform = CharacterManager.Instance.player.transform;

        direction = playerTransform.position - transform.position;

        SetRotation(direction.normalized);

        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position,
            Time.deltaTime * speed);
    }
    #endregion

    private void SetLastWaypoint()
    {
        if (waypointsQueueList.Count == 1)
            lastWaypoint = waypointsQueueList[0];
    }

    private void MoveToWaypoint()
    {
        direction = waypointsQueueList[0].position - transform.position;
        
        SetRotation(direction.normalized);

        transform.position = Vector3.MoveTowards(transform.position, waypointsQueueList[0].position, Time.deltaTime * speed);

        if (transform.position == waypointsQueueList[0].position)
            UnQueueWaypoint(waypointsQueueList[0]);
    }
    private void UnQueueWaypoint(Transform waypoint)
    {
        waypointsQueueList.Remove(waypoint);
    }
    private void SetupQueue()
    {
        if(lastWaypoint == waypointsList[0])
            waypointsQueueList = new List<Transform>(waypointsList);
        if (lastWaypoint == waypointsList[waypointsList.Count - 1])
            ReverceQueue();
    }
    private void ReverceQueue()
    {
        waypointsQueueList = new List<Transform>(waypointsList);
        waypointsQueueList.Reverse();
    }

    private void SetRotation(Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    #endregion

    enum State { Patrol,  Idle, Pursuit, Fight}
}
