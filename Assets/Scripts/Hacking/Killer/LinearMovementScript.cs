using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovementScript : MonoBehaviour {

    #region Variables
    [SerializeField] private float speed,destination;
    #endregion

    Vector3 startPos,destPos;
    int direction = 1;

    void Start()
    {
        startPos = transform.position;
        destPos = new Vector3(startPos.x + destination, startPos.y);
        
        
    }


	void Update () {
        transform.Translate(transform.right * Time.deltaTime * speed*direction);
        
        if (Vector3Int.RoundToInt(transform.position) == Vector3Int.RoundToInt(destPos))
        {
            
            transform.localRotation = Quaternion.Euler(180, 0, 0);
            direction = -1;
        }
        else if (Vector3Int.RoundToInt(transform.position) == Vector3Int.RoundToInt(startPos))
        {
            
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            direction = 1;
        }
        

    }
}
