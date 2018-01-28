using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitiateHackScript : MonoBehaviour {

    #region Inspector Vars
    [SerializeField] private AudioSource initiateHackSound;
    [SerializeField] private string sceneName;
    #endregion

    void Start()
    {
        initiateHackSound = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameController.lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
            initiateHackSound.Play();
            Invoke("InitiateHack", 0.2f);
        }
    }

    void InitiateHack()
    {
        SceneManager.LoadScene(sceneName);
    }

}
