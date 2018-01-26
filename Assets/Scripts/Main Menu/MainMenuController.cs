using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    [SerializeField]Button playButton;
    [SerializeField]Button optionsButton;
    [SerializeField]Button exitButton;

    void Start()
    {

        playButton.onClick.AddListener(delegate { Play(); });
        optionsButton.onClick.AddListener(delegate { Options(); });
        exitButton.onClick.AddListener(delegate { Exit(); });
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }

    private void Options()
    {

    }

    private void Exit()
    {
        Application.Quit();
    }
}
