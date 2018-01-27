using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitiateHackScript : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("HAKUJ DZIDO");
            SceneManager.LoadScene("Level_1");
        }
    }

}
