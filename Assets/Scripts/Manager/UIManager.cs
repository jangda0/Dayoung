using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum UIState
{
    Home,
    GameOver,
    Main,
    Panel
}

public class UIManager : MonoBehaviour
{
    HomeUI homeUI;
    GameOverUI gameOverUI;
    MainUI mainUI;
    PanelUI panelUI;

    private UIState currentState;

    private void Awake()
    {
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI.Init(this);
        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI.Init(this);
        mainUI = GetComponentInChildren<MainUI>(true);
        mainUI.Init(this);
        panelUI = GetComponentInChildren<PanelUI>(true);
        panelUI.Init(this);

        ChangeState(UIState.Main);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Main);
    }

    public void SetGameOver()
    {
        ChangeState(UIState.GameOver);
    }

    public void ChangePlayerHP(float currentHP, float maxHP)
    {
        mainUI.UpdateHPSlider(currentHP / maxHP);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI.SetActive(currentState);
        gameOverUI.SetActive(currentState);
        mainUI.SetActive(currentState);
        panelUI.SetActive(currentState);
    }

    public void Dialog()
    {
        ChangeState(UIState.Panel);
    }
}
