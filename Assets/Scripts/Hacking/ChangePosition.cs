using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour {

    #region Variables
    public Transform gameObjectTransform;
    #endregion

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            coll.transform.position = gameObjectTransform.transform.position;
    }
}
