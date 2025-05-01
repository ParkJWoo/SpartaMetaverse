using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GameOverUI : BaseUI
{
    GameManager gameManager;

    TextMeshProUGUI scoreText;
    TextMeshProUGUI bestScoreText;

    Button startButton;
    Button exitButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        gameManager = FindObjectOfType<GameManager>();

        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        bestScoreText = transform.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
        startButton = transform.Find("RestartButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();

        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }

    public void SetUI(int score, int bestScore)
    {
        scoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    void OnClickStartButton()
    {
        gameManager.RestartGame();
        //uiManager.OnClickStart();
    }

    void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }
}
