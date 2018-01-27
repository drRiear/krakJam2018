using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneOnDeath : MonoBehaviour {

    [SerializeField] private AudioSource audio;




    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {


            Invoke("Reset",0.3f);
            PlaySource();
        }
            
    }

    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void PlaySource()
    {
        audio.Play();
    }

}
