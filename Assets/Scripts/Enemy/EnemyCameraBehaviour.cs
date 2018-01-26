using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraBehaviour : MonoBehaviour {

    #region Inspector Vars
    [Header("Rotation")]
    [SerializeField] private float angleOfRotation;
    [Header("View")]
    [SerializeField] private float distanceOfView;
    [SerializeField] private float angleOfView;
    [SerializeField] private float inIdleTime;
    #endregion

    #region Private Vars
    [SerializeField] private State state = 0;

    private Quaternion startRotation;
    private Quaternion finalRotation;

    private Quaternion destinationRotation;

    private float rotationLerpT;

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
                rotationLerpT = 0.0f;

                inIdleTimer -= Time.deltaTime;

                if (inIdleTimer <= 0.0f)
                    state = State.Rotating;

                break;
            case State.Rotating:

                inIdleTimer = inIdleTime;

                SetRotation();

                //print(rotationLerpT);
                

                break;
        }
    }

    public float rotationDirection = 1;
    private float rotationSpeed = 20;

    private void SetDestinationZRotation()
    {
        if (transform.rotation == startRotation)
            rotationDirection = 1;
        if (transform.rotation == finalRotation)
            rotationDirection = -1;
    }

    private void SetRotation()
    {
        SetDestinationZRotation();

        var newRotation = Quaternion.RotateTowards(transform.rotation, finalRotation, Time.deltaTime * rotationDirection * rotationSpeed);

        print(newRotation);

        transform.rotation = newRotation;

        rotationLerpT += Time.deltaTime;
    }

    #endregion

    private enum State { Idle, Rotating };
}
