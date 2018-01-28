using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonMatChanger : MonoBehaviour
{

    [SerializeField] private Material green;
    [SerializeField] private Material red;

    private SpriteRenderer rend;

    private Mat mat;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(GameController.isHacked)
            SetMaterial(Mat.Green);
        if (!GameController.isHacked)
            SetMaterial(Mat.Red);
    }

    private void SetMaterial(Mat newMat)
    {
        if (mat == newMat) return;

        mat = newMat;

        switch (mat)
        {
            case Mat.Green:
                rend.material = green;
                break;
            case Mat.Red:
                rend.material = red;
                break;

        }
    }

    enum Mat { Red, Green }
}
