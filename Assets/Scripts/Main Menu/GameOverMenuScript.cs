using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenuScript : MonoBehaviour { 
    [SerializeField]Button exitButton;
    [SerializeField]Button returnButton;

    void Start()
    {
        exitButton.onClick.AddListener(delegate { Exit(); });
        returnButton.onClick.AddListener(delegate { Return(); });
    }

    private void Exit()
    {
        Application.Quit();
    }
    private void Return()
    {
        SceneManager.LoadScene(GameController.lastSceneIndex); 
    }
}
