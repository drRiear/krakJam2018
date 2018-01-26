using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseButtonScript : MonoBehaviour {

    #region Variables
    [SerializeField] private BlockadeRelease blockade;
    #endregion

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "Player")
            blockade.Release();
    }
}
