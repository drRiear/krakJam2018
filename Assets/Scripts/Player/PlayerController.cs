using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    #region Inspector Vars
    [SerializeField] private float speed;
    
    #endregion

    private Rigidbody2D rb;
    private Vector3 movementDirection;

    #region Unity events
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        CharacterManager.Instance.player = gameObject;
    }
    private void Update()
    {
        Movement();

        SetMovementRotation();
    }
    #endregion

    #region Private Methods

    private void Movement()
    {
        movementDirection = new Vector3 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (movementDirection == Vector3.zero) return;

        var force = movementDirection * speed * Time.deltaTime;

        rb.AddForce(force);
    }

    private void SetMovementRotation()
    {
        if (movementDirection.x > 0)
            transform.localEulerAngles = Vector3.zero;
        if (movementDirection.x < 0)
            transform.localEulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
        if (movementDirection.y > 0)
            transform.localEulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
        if (movementDirection.y < 0)
            transform.localEulerAngles = new Vector3(0.0f, 0.0f, 270.0f);
    }

    #endregion



}
