using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TeleportToScene : MonoBehaviour
{
#if UNITY_EDITOR
    public SceneAsset nextScene;
#endif

    public string nextSceneName; // Dodana publiczna zmienna na nazwę sceny

    void Start()
    {
#if UNITY_EDITOR
        if (nextScene != null)
        {
            nextSceneName = nextScene.name;
        }
        else
        {
            Debug.LogError("Next scene asset is not set!");
        }
#endif

        // Debugowanie
        Debug.Log("Next level scene name set to: " + nextSceneName);
    }

    void OnTriggerEnter(Collider other)
    {
        // Debugowanie
        Debug.Log("Collision detected with: " + other.name);

        if (other.CompareTag("Player"))
        {
            // Debugowanie
            Debug.Log("Player detected, loading next level...");
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            // Debugowanie
            Debug.Log("Loading scene: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set!");
        }
    }
}
