using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraBehaviour : MonoBehaviour {

    #region Inspector Vars
    [Header("Rotation")]
    [SerializeField] private float speedOfRotation;
    [SerializeField] private float angleOfRotation;
    [Header("View")]
    [SerializeField] private float distanceOfView;
    [SerializeField] private float angleOfView;
    #endregion

    #region Private Vars
    [SerializeField] private State state = 0;

    private Quaternion startRotation;
    private Quaternion destinationRotation = new Quaternion();
    private float rototionLerpT;
    #endregion

    #region Unity Events
    void Start ()
    {
        startRotation = transform.rotation;
        destinationRotation.eulerAngles = new Vector3(0.0f, 0.0f, angleOfRotation);
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

                break;
            case State.Rotating:

                SetRotation(rototionLerpT);
                rototionLerpT += Time.deltaTime;

                break;
        }
    }

    private void SetRotation(float _t)
    {
        var currentZRotation = transform.rotation.z;
        var newZRotation = Mathf.Lerp(currentZRotation, destinationRotation.z, _t);
        //transform.Rotate();
    }

    #endregion

    private enum State { Idle, Rotating };
}
