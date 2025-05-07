using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController player { get; private set; }
    private ResourceController _playerResourceController;

    private UIManager uiManager;

    public static bool isFirstLoating = true;

    private void Awake()
    {
        instance = this;

        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        uiManager = FindObjectOfType<UIManager>();

        _playerResourceController = player.GetComponent<ResourceController>();
        _playerResourceController.RemoveHealthChangeEvent(uiManager.ChangePlayerHP);
        _playerResourceController.AddHealthChangeEvent(uiManager.ChangePlayerHP);
    }

    private void Start()
    {
        if (!isFirstLoating)
        {
            StartGame();
        }
        else
        {
            isFirstLoating = false;
        }
    }

    public void StartGame()
    {
        uiManager.SetPlayGame();
    }



    public void GameOver()
    {
        uiManager.SetGameOver();
    }


}
