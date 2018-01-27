using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorButtonScript : MonoBehaviour
{


    public AudioSource openDoorSound;

    void Start()
    {
        openDoorSound = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
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
