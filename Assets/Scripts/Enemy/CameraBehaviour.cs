using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    #region Inspector Vars
    [Header("Rotation")]
    [SerializeField] private float angleOfRotation;
    [SerializeField] private float rotationSpeed;
    [Header("Idle")]
    [SerializeField] private float inIdleTime;
    #endregion

    #region Hiden Vars

    [HideInInspector] public Quaternion startRotation;
    [HideInInspector] public Quaternion destinationRotation;
    public State state = 0;

    #endregion

    #region Private Vars
    private Transform playerTransform;
    private Quaternion finalRotation;
    private float rotationDirection = 1;
    public float inIdleTimer;
    #endregion

    #region Unity Events
    void Start ()
    {
        playerTransform = CharacterManager.Instance.player.transform;
        inIdleTimer = inIdleTime;
        startRotation = transform.rotation;
        finalRotation.eulerAngles = new Vector3(0.0f, 0.0f, transform.rotation.eulerAngles.z + angleOfRotation);
        
    }
	void Update ()
	{
        SetState();
	}
    #endregion
    
    #region Private methods
    private void SetState()
    {
        switch (state)
        {
            case State.Idle:
                inIdleTimer -= Time.deltaTime;

                if (inIdleTimer <= 0.0f)
                    state = State.Rotating;

                break;
            case State.Rotating:
                inIdleTimer = inIdleTime;

                SetRotation();

                break;

            case State.LockOnPlayer:
                Lock();
                break;
            case State.Alarm:
                destinationRotation = startRotation;
                
                break; 
        }
    }

    private void Lock()
    {
        var difference = transform.position - playerTransform.position;
        difference.Normalize();
        difference.z = 0.0f;

        float rot_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    private void SetRotation()
    {
        SetDestinationRotation();

        transform.rotation = Quaternion.RotateTowards(transform.rotation, destinationRotation,
            Time.deltaTime * rotationDirection * rotationSpeed);
    }

    private void SetDestinationRotation()
    {
        if (transform.rotation == startRotation)
        {
            state = State.Idle;
            destinationRotation = finalRotation;
        }

        if (transform.rotation == finalRotation)
        {
            state = State.Idle;
            destinationRotation = startRotation;
        }
    }
    #endregion

    public enum State { Idle, Rotating, LockOnPlayer, Alarm }
}
