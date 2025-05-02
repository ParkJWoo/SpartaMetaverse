using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterMiniGameUI : BaseUI
{
    Button startButton;
    Button closeButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        startButton = transform.Find("StartButton").GetComponent<Button>();
        closeButton = transform.Find("CloseButton").GetComponent<Button>();

        startButton.onClick.AddListener(OnClickStartButton);
        closeButton.onClick.AddListener(OnClickCloseButton);
    }

    protected override UIState GetUIState()
    {
        return UIState.EnterMiniGame;
    }

    void OnClickStartButton()
    {
        uiManager.OnClickEnterMiniGame();
    }

    void OnClickCloseButton()
    {
        uiManager.UIStateNone();
    }
}
