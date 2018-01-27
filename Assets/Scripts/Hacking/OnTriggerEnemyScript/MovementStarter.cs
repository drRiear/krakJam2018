using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStarter : MonoBehaviour {

    #region
    [SerializeField] private TriggerEnemyMovement trigger;
    #endregion


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            trigger.Trigger = true;
        }

    }

}
