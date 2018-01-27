using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyMovement : MonoBehaviour {

    #region
    [SerializeField] private float speed;
    [SerializeField] private bool isOX;
    [SerializeField] private bool change_direction;
    #endregion

    private int dir = 1;
    private bool trigger;
    public bool Trigger
    {
        set { trigger = value; }
    }



    void Start()
    {
        if (change_direction)
        {
            dir = -1;
        }
        
    }
    void Update()
    {
        if (trigger)
        {
            Movement();
        }

    }

    public void Movement()
    {
        if (isOX)
        {
            transform.Translate(transform.right * Time.deltaTime * speed * dir);
        }
        else
        {
            transform.Translate(transform.up * Time.deltaTime * speed * dir);
        }
        
    }
}
