using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitiateHackScript : MonoBehaviour {


    public AudioSource initiateHackSound;
    
    void Start()
    {
        initiateHackSound = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
    
            Invoke("InitiateHack", 0.2f);
        }
    }

    void InitiateHack()
    {
        SceneManager.LoadScene("Level_1");
    }

}
