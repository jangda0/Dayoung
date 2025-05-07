using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniBoard : MonoBehaviour
{
    static MiniBoard miniBoard;

    public static MiniBoard Instance { get { return miniBoard; } }

    private int currentScore = 0; //���� ����

    UIManagerMini uiManagerMini; //UI �Ŵ���
    public UIManagerMini UIManagerMini { get { return uiManagerMini; } }


    private void Awake()
    {
        miniBoard = this;
        uiManagerMini = FindObjectOfType<UIManagerMini>();
    }

    private void Start()
    {
        uiManagerMini.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManagerMini.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManagerMini.UpdateScore(currentScore);
    }
}
