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

    void ChangeCollision() {
        int previousIndex;
        if(actualIndex == 0) {
            previousIndex = list.Count-1;
        } else
            previousIndex = actualIndex - 1;
        
        list[actualIndex].SetActive(false);
        
        list[previousIndex].SetActive(true);

        if(actualIndex == list.Count-1)
            actualIndex = 0;
        else
            actualIndex += 1;
    }
}
