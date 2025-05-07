using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    StartScene,
    MainScene,
    MiniGameScene
}

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void LoadScene(SceneType _scene)
    {
        // _scene에 따라 씬 이름을 매핑
        string sceneName = _scene.ToString();
        Debug.Log($"Loading scene: {sceneName}");
        SceneManager.LoadScene(sceneName);
    }
}
