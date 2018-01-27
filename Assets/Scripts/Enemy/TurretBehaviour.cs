using UnityEngine;
using System.Collections;

public class TurretBehaviour : MonoBehaviour
{
    #region Inspector Vars
    [SerializeField] private float rotationSpeed = 10;
    [SerializeField] private float angleStep = 60;
    [SerializeField] private float rotateDelay = 2;
    [SerializeField] private float shootDelay = 0.5f;
    [SerializeField] private GameObject projectilePrefub;
    #endregion

    public State state;

    #region Private Vars

    private float timer;
    private Transform playerTransform;
    private Quaternion quaternionStep;
    public bool isSooted = true;

    #endregion

    #region Unity Event
    void Start()
    {
        playerTransform = CharacterManager.Instance.player.transform;
        quaternionStep.eulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z + angleStep);
        timer = rotateDelay;
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
            case State.LockOnPlayer:
                Lock();

                if (!isSooted)
                {
                    isSooted = true;
                    Instantiate(projectilePrefub, transform.position, Quaternion.identity);
                }

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

    private void Idle()
    {
        timer -= Time.deltaTime;

        quaternionStep.eulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z + angleStep);

        if (timer <= 0.0f)
            state = State.Rotating;
    }

    private void Rotating()
    {
        timer = rotateDelay;

        Rotate();

        if (transform.rotation == quaternionStep)
            state = State.Idle;
    }

    #endregion

    public enum State { Idle, Rotating, LockOnPlayer, Alarm }
    
}
