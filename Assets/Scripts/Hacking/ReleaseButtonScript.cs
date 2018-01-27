using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseButtonScript : MonoBehaviour {

    #region Variables
    [SerializeField] private BlockadeRelease blockade;
    [SerializeField] private AudioSource audio;
    #endregion

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "Player") {
            this.gameObject.SetActive(false);
            blockade.Release();
            PlaySource();
        }
    }

    void PlaySource()
    {
        audio.Play();
    }
}
