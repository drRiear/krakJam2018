using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject door;

    public AudioSource openDoorSound;

    private Collider2D doorCollider;
    private SpriteRenderer doorRenderer;
    private AudioSource doorSound;



    void Start()
    {
        openDoorSound = GetComponent<AudioSource>();

        doorCollider = door.GetComponent<BoxCollider2D>();
        doorRenderer = door.GetComponent<SpriteRenderer>();
        doorSound = door.GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButtonDown("Interaction") && GameController.isHacked)
        {
            openDoorSound.Play();
            Invoke("OpenDoor", 1.5f);
            
        }
    }

    void OpenDoor()
    {
        DoorScript.collider.enabled = false;
        DoorScript.renderer.enabled = false;
        DoorScript.doorSound.Play();
    }

}
