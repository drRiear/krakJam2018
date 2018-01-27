using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WziuumControler : MonoBehaviour {

    #region Variables
    [SerializeField] private List<GameObject> list = new List<GameObject>();
    [SerializeField] private float delay;
    [SerializeField] private float interval;
    #endregion

    private ChangePosition resetTransform;
    private int actualIndex = 0;

    void Start()
    {
        resetTransform = GetComponent<ChangePosition>();
        InvokeRepeating("Wziuum", delay, interval);
    }

    void Wziuum()
    {
        int previousIndex;
        if (actualIndex == 0)
        {
            previousIndex = list.Count - 1;
        }
        else
            previousIndex = actualIndex - 1;

        

        resetTransform.gameObjectTransform = list[actualIndex].transform;
       
        

        if (actualIndex == list.Count - 1)
            actualIndex = 0;
        else
            actualIndex += 1;
    }
}
