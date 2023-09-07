using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private static LevelLoader _instance;
    public static LevelLoader Instance
    {
        get => _instance;
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
        }

        _instance = this;

        DontDestroyOnLoad(this);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance);
        }
    }

    public void LoadScoreBoard()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(SceneManager.sceneCountInBuildSettings > currentSceneIndex)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.LogWarning("last level");
            if (GameManager.Instance != null)
            {
                GameManager.Instance.EndGame();
            }
        }
    }
}
