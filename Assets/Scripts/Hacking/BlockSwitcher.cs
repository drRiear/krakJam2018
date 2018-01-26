using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSwitcher : MonoBehaviour {

    #region Variables
    [SerializeField] private List<GameObject> list = new List<GameObject>();
    [SerializeField] private float delay;
    [SerializeField] private float interval;
    #endregion

    private int actualIndex = 0;

    void Start () {
        InvokeRepeating("ChangeCollision", delay, interval);
    }
	
	
	void Update () {
        
    }

    void ChangeCollision() {
        int previousIndex;
        if(actualIndex == 0) {
            previousIndex = list.Count-1;
        } else
            previousIndex = actualIndex - 1;

        list[actualIndex].GetComponent<SpriteRenderer>().enabled = false;
        list[actualIndex].GetComponent<Collider2D>().enabled = false;

        list[previousIndex].GetComponent<SpriteRenderer>().enabled = true;
        list[previousIndex].GetComponent<Collider2D>().enabled = true;

        if(actualIndex == list.Count-1)
            actualIndex = 0;
        else
            actualIndex += 1;
    }
}
