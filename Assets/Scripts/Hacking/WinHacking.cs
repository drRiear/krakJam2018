using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinHacking : MonoBehaviour {

    #region Inspector Vars
    [SerializeField] private string sceneName;
    [SerializeField] private AudioSource sound;
    [SerializeField] private float LoadDelay;
    #endregion

    private bool isTriggered = false;

    void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && !isTriggered) {
            isTriggered = true;
            PlaySource();
            GameController.isHacked = true;
            Invoke("InitiateScene", LoadDelay);
        }
    }

    void InitiateScene() {
        SceneManager.LoadScene(sceneName);
    }

    void PlaySource() {
        sound.Play();
    }
}