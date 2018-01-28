using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour {

    #region Variables
    public Transform gameObjectTransform;
    private Collider2D coll;
    private Rigidbody2D rigidb;
    [SerializeField] private AudioSource audio;
    [SerializeField] private float delay = .5f;
    #endregion

    void OnTriggerEnter2D(Collider2D _coll)
    {
        if(rigidb == null)
            rigidb = _coll.GetComponent<Rigidbody2D>();
         
        if (_coll.gameObject.tag == "Player")
        {
            coll = _coll;
            coll.enabled = false;
            Invoke("Teleport", delay);
        }
    }

    private void Teleport() {
        coll.transform.position = gameObjectTransform.transform.position;
        rigidb.constraints = RigidbodyConstraints2D.FreezePosition;
        coll.enabled = true;
        Invoke("SetFree", 0.5f);
        PlaySource();
    }

    void SetFree()
    {
        rigidb.constraints = RigidbodyConstraints2D.None;
    }

    void PlaySource()
    {
        audio.Play();
    }
}
