using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {


    public static Collider2D collider;
    public static SpriteRenderer renderer;

    public static AudioSource elevatorSound;

	void Start () {
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
        elevatorSound = GetComponent<AudioSource>();
        	
	}
}
