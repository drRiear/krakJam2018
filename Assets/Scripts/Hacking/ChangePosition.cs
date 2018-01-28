using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour {

    #region Variables
    public Transform gameObjectTransform;
    private Rigidbody2D rigidbody;
    [SerializeField] private AudioSource audio;
    #endregion

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(rigidbody==null)
            rigidbody = coll.GetComponent<Rigidbody2D>();
         
        if (coll.gameObject.tag == "Player")
        {
            coll.transform.position = gameObjectTransform.transform.position;
            rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            Invoke("SetFree", 0.5f);
            PlaySource();
        }
    }

    void SetFree()
    {
        rigidbody.constraints = RigidbodyConstraints2D.None;
    }

    void PlaySource()
    {
        audio.Play();
    }
}
