using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneOnDeath : MonoBehaviour {

    [SerializeField] private AudioSource audioSrc;
    [SerializeField] private float delay = .8f;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Invoke("Reset", delay);
            PlaySource();
        }
            
    }

    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void PlaySource()
    {
        audioSrc.Play();
    }

}
