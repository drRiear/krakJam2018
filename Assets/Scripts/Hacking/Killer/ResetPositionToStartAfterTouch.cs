using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionToStartAfterTouch : MonoBehaviour {

    #region Variables
    [SerializeField] private GameObject gameObjectPosition;
    #endregion

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            coll.transform.position = gameObjectPosition.transform.position;
    }
}
