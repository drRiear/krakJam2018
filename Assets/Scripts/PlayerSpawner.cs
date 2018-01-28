using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform hackedPoint;
    [SerializeField] private Transform playerTransform;


	void OnEnable ()
	{
        if(GameController.isHacked)
	        playerTransform.position = hackedPoint.position;
	    if (!GameController.isHacked)
            playerTransform.position = startPoint.position;

    }
}
