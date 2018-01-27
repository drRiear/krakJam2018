using UnityEngine;
using System.Collections;

public class TurretBehaviour : MonoBehaviour
{
    #region Inspector Vars

    private float rotationSpeed = 10;
    private float angleStep = 60;
    private float delay = 2;

    #endregion

    #region Private Vars

    private float timer;
    private  State state;
    private Quaternion quaternionStep;

    #endregion

    #region Unity Event

    void Start()
    {
        quaternionStep.eulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z + angleStep);
        timer = delay;
    }
    
    void Update()
    {
        SetState();
    }
    #endregion

    #region Private Methods

    private void Rotate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternionStep,
            Time.deltaTime * rotationSpeed);
    }
    private void SetState()
    {
        switch (state)
        {
            case State.Idle:
                Idle();

                break;
            case State.Rotating:
                Rotating();

                break;
        }
    }

    private void Idle()
    {
        timer -= Time.deltaTime;

        quaternionStep.eulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z + angleStep);

        if (timer <= 0.0f)
            state = State.Rotating;
    }

    private void Rotating()
    {
        timer = delay;

        Rotate();

        if (transform.rotation == quaternionStep)
            state = State.Idle;
    }

    #endregion

    public enum State { Idle, Rotating };
    
}
