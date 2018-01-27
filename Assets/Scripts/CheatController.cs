using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatController : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown(KeyCode.C))
        {
            print("Oszust");
            GameController.isHacked = true;
            SceneManager.LoadScene(GameController.lastSceneIndex-1); 
        }
    }
}
