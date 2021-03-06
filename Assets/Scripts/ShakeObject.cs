﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObject:MonoBehaviour {

    #region Inspector Vars
    [SerializeField] public float shake_decay = 0.002f;
    [SerializeField] public float shake_intensity = .3f;
    #endregion

    private Vector3 originPosition;
    private Quaternion originRotation;
    private float temp_shake_intensity = 0;

    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.layer == 9) {
            Shake();
        }
    }

    void Update() {
        if(temp_shake_intensity > 0) {
            transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
            transform.rotation = new Quaternion(
                originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);
            temp_shake_intensity -= shake_decay;
        }
    }

    void Shake() {
        originPosition = transform.position;
        originRotation = transform.rotation;
        temp_shake_intensity = shake_intensity;

    }
}
