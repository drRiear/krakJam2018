using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenuScript : MonoBehaviour { 
    [SerializeField]Button exitButton;

    void Start()
    {
        exitButton.onClick.AddListener(delegate { Exit(); });
    }

    private void Exit()
    {
        Application.Quit();
    }
}
