using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    #region Inspector Vars
    [SerializeField] private float speed;
    #endregion
    
    void Update()
    {
        Movement();
    }

    #region Private Methods

    private void Movement()
    {
        var direction = new Vector3 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        transform.Translate(direction * speed * Time.deltaTime);
    }
    #endregion  
}
