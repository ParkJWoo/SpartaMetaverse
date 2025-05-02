using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUI : BaseUI
{
    TextMeshProUGUI scoreText;

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    public void SetUI(int score)
    {
        scoreText.text = score.ToString();
    }
}