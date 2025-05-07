using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelUI : BaseUI
{
    [SerializeField] private Button MiniGameButton;
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        MiniGameButton.onClick.AddListener(OnClickSceneChange);
    }

    private void Start()
    {

    }

    public void OnClickSceneChange()
    {
        if (LoadSceneManager.Instance == null)
        {
            Debug.LogError("LoadSceneManager.Instance가 null입니다.");
            return;
        }

        Debug.Log("MiniGameScene으로 전환을 시도합니다.");
        LoadSceneManager.Instance.LoadScene(SceneType.MiniGameScene);
    }

    protected override UIState GetUIState()
    {
        return UIState.Panel;
    }
}
