using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBehaviour : MonoBehaviour
{

    #region Inspector Variables
    public float speed;
    [SerializeField] private int distance;
    [SerializeField] private bool isOX;
    [SerializeField] private float distanceOfView;
    #endregion

    #region Private Variables
    private Vector3 startPos, destPos;
    private int direction = 1;
    private Vector3 directionOfView;
    #endregion


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        directionOfView = isOX ? transform.right * distanceOfView : transform.up * distanceOfView;

        Gizmos.DrawRay(transform.position, directionOfView);
    }
    void Start()
    {
        startPos = transform.position;
        destPos = isOX ? new Vector3(startPos.x + distance, startPos.y) : new Vector3(startPos.x, startPos.y + distance);
    }

    void Update()
    {
        Movement();

        LookForPlayer();
    }

    private void Movement()
    {
        if (isOX)
            transform.Translate(transform.right * Time.deltaTime * speed * direction);
        else
            transform.Translate(transform.up * Time.deltaTime * speed * direction);

        if (Vector3Int.RoundToInt(transform.position) == Vector3Int.RoundToInt(destPos))
        {
            transform.localRotation = Quaternion.Euler(180, 0, 0);
            direction = -1;
            
        }
        else if (Vector3Int.RoundToInt(transform.position) == Vector3Int.RoundToInt(startPos))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            direction = 1;
        }
    }

    private void LookForPlayer()
    {
        var hits = Physics2D.RaycastAll(transform.position, directionOfView * distanceOfView);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject == CharacterManager.Instance.player)
            {
                GameController.isDetectedByEnemy = true;
                break;
            }
            
            GameController.isDetectedByEnemy = false;
        }
    }
}