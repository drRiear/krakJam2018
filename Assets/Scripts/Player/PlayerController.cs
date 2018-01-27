using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    #region Inspector Vars
    [SerializeField] private float speed;

    [Header("Layers names")]
    [SerializeField] private string wallLayerMask;
    #endregion

    private Rigidbody2D rb;

    #region Unity events
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Movement();
    }
    #endregion

    #region Private Methods

    private void Movement()
    {
        var direction = new Vector3 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (direction == Vector3.zero) return;

        var force = direction * speed * Time.deltaTime;

        rb.AddForce(force);
    }

    #endregion  
}
