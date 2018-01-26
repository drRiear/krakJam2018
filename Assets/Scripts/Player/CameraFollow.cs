using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Inpector Vars
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;
    #endregion

    void Update ()
    {
        transform.position = playerTransform.position + offset;
    }
}
