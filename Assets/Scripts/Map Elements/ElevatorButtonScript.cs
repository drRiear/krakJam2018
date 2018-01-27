using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorButtonScript : MonoBehaviour
{


    public AudioSource openElevatorSound;

    void Start()
    {
        openElevatorSound = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (GameController.isHacked == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                openElevatorSound.Play();
                Invoke("OpenElevator", 1.5f);
                GameController.isHacked = false;
            }
        }else
            print("Nimo danych");
        
    }

    void OpenElevator()
    {
        //SceneManager.LoadScene(NASTEPNA SCENA);
    }

}
