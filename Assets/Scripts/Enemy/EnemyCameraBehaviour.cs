using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraBehaviour : MonoBehaviour {

    #region Inspector Vars
    [Header("Rotation")]
    [SerializeField] private float angleOfRotation;
    [SerializeField] private float rotationSpeed;
    [Header("Idle")]
    [SerializeField] private float inIdleTime;
    #endregion

    #region Private Vars
    private State state = 0;

    private Quaternion startRotation;
    private Quaternion finalRotation;

    private Quaternion destinationRotation;

    private float rotationDirection = 1;

    private float inIdleTimer;
    #endregion

    #region Unity Events
    void Start ()
    {
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
        }
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

    private enum State { Idle, Rotating };
}
