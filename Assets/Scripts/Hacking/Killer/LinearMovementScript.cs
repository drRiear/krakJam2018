using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovementScript : MonoBehaviour {

    #region Variables
    [SerializeField] private float speed;
    [SerializeField] private int distance;
    [SerializeField] private bool isOX;
    #endregion

    private Vector3 startPos, destPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
        if(isOX) {
            destPos = new Vector3(startPos.x + distance, startPos.y);
        } else {
            destPos = new Vector3(startPos.x, startPos.y + distance);
        }
    }


	void Update () {
        if(isOX) {
            transform.Translate(transform.right * Time.deltaTime * speed*direction);
        } else {
            transform.Translate(transform.up * Time.deltaTime * speed*direction);
        }
        
        if (Vector3Int.RoundToInt(transform.position) == Vector3Int.RoundToInt(destPos)){
            
            transform.localRotation = Quaternion.Euler(180, 0, 0);
            direction = -1;
        }else if (Vector3Int.RoundToInt(transform.position) == Vector3Int.RoundToInt(startPos)){
            
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            direction = 1;
        }
        

    }
}
