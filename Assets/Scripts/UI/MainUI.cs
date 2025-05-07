using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : BaseUI
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider mpSlider;
    [SerializeField] private Slider expSlider;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        menuButton.onClick.AddListener(OnClickMenuButton);
    }

    private void Start()
    {
        UpdateHPSlider(1);
        UpdateMPSlider(1);
        UpdateEXPSlider(1);
    }

    public void OnClickMenuButton()
    {

    }

    public void UpdateHPSlider(float percentage)
    {
        hpSlider.value = percentage;
    }

    public void UpdateMPSlider(float percentage)
    {
        mpSlider.value = percentage;
    }

    public void UpdateEXPSlider(float percentage)
    {
        expSlider.value = percentage;
    }

    protected override UIState GetUIState()
    {
        return UIState.Main;
    }
}
