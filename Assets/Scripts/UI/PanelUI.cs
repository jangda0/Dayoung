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
            Debug.LogError("LoadSceneManager.Instance�� null�Դϴ�.");
            return;
        }

        Debug.Log("MiniGameScene���� ��ȯ�� �õ��մϴ�.");
        LoadSceneManager.Instance.LoadScene(SceneType.MiniGameScene);
    }

    protected override UIState GetUIState()
    {
        return UIState.Panel;
    }
}
