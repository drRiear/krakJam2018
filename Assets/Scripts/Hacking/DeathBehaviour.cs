using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehaviour : MonoBehaviour {

    #region Inspector Vars
    [SerializeField] public float shakeDecay = 0.01f;
    [SerializeField] public float shakeIntensity = .3f;
    [SerializeField] private AudioSource transferAudio;
    [SerializeField] private Transform transferTo;
    #endregion

    #region Vars
    private Rigidbody2D rigidb;
    private Vector3 originPosition;
    private Quaternion originRotation;
    private float temp_shake_intensity = 0;
    private bool isTeleport = false;
    #endregion

    void OnTriggerEnter2D(Collider2D _coll) {
        if(rigidb == null)
            rigidb = GetComponent<Rigidbody2D>();

        if(_coll.gameObject.layer == 9) {
            isTeleport = true;
            Shake();
        }
    }

    private void ChangePosition() {
        transform.position = transferTo.transform.position;
        rigidb.constraints = RigidbodyConstraints2D.FreezePosition;
        Invoke("SetFree", 0.5f);
        transferAudio.Play();
    }

    private void SetFree() {
        rigidb.constraints = RigidbodyConstraints2D.None;
    }

    private void Shake() {
        originPosition = transform.position;
        originRotation = transform.rotation;
        temp_shake_intensity = shakeIntensity;
    }

    void Update() {
        if(temp_shake_intensity > 0) {
            transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
            transform.rotation = new Quaternion(
                originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);
            temp_shake_intensity -= shakeDecay;
        } else if(isTeleport) {
            ChangePosition();
            temp_shake_intensity = 0;
            isTeleport = false;
        }
    }
}
