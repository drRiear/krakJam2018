using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAllEnemies : MonoBehaviour {


    KeyCode[] konamicode;
    int currentKeyIndex = 0;
    private bool isKeyOK = false;

    void Start()
    {
        konamicode = new KeyCode[]{KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow,
    KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A};
    }


    void Update()
    {
        if (isKeyOK)
        {
            FindGameObjWithLayer(9);
            isKeyOK = false;
        }
    }

    void FindGameObjWithLayer (int layer)
    {
        var goArray = FindObjectsOfType<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == layer)
            {
                goArray[i].SetActive(false);
            }
        }
    }
    void OnGUI()
    {

        Event e = Event.current;
        if (e.isKey && Input.anyKeyDown && !isKeyOK && e.keyCode.ToString() != "None")
        {
            konamiFunction(e.keyCode);

        }

    }
    void konamiFunction(KeyCode keyCode)
    {
        string KeyinString = keyCode.ToString();
        if (KeyinString == konamicode[currentKeyIndex].ToString())
        {

            currentKeyIndex++;
            if (currentKeyIndex >= konamicode.Length)
            {

                isKeyOK = true;
            }
        }
        else
        {

            currentKeyIndex = 0;
        }
    }


}
