using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagerMini : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    // Start is called before the first frame update
    void Start()
    {
        if (restartText == null)
            Debug.LogError("Not Founded Restart Text");

        if (scoreText == null)
            Debug.LogError("Not Founded Score Text");

        restartText.gameObject.SetActive(false);

    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
