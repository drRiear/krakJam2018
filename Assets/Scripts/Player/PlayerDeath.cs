using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public int nextSceneIndex;

    public void Die()
    {
        GameController.lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nextSceneIndex);

        GameController.isDetectedByCamera = false;
        GameController.isDetectedByEnemy = false;
    }
}