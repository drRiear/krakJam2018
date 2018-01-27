using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneOnDeath : MonoBehaviour {

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        
        spriteRenderer.enabled = false;
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = true;

            Invoke("Reset", 2);
        }
            
    }

    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
