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

    private float destinationZRotation;

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

                if (rotationLerpT >= 1)
                    state = State.Idle;

                break;
        }
    }

    //private void SetDestinationZRotation()
    //{
    //    if (transform.rotation == startRotation)
    //        destinationZRotation = finalRotation.eulerAngles.z;
    //    if (transform.rotation == finalRotation)
    //        destinationZRotation = startRotation.eulerAngles.z;
    //}

    private void SetRotation()
    {
        var newZRotation = Mathf.Lerp(startRotation.eulerAngles.z, finalRotation.eulerAngles.z, rotationLerpT);

        print(newZRotation);

        transform.Rotate(new Vector3(0.0f, 0.0f, newZRotation));
        rotationLerpT += Time.deltaTime ;
    }

    #endregion

    private enum State { Idle, Rotating };
}
