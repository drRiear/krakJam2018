using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public string nextSceneName;

    public void Die()
    {
        GameController.lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nextSceneName);

        GameController.isDetectedByCamera = false;
        GameController.isDetectedByEnemy = false;
    }
}