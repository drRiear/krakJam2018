using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraBehaviour : MonoBehaviour {

    #region Inspector Vars

    [SerializeField] private float speedOfRotation;
    [SerializeField] private float angleOfRotation;
    #endregion


    void Start () {
		
	}
	
	
	void Update () {
		
	}

    private enum State { Idle, Rotating };
}
