using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelScript : MonoBehaviour {


    
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            Debug.Log("Dupa123");



    }
}
