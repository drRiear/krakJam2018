using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
    
    public static Collider2D collider;
    public static SpriteRenderer renderer;
    public static AudioSource doorSound;

	void Start () {
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
        doorSound = GetComponent<AudioSource>();
        	
	}
}
