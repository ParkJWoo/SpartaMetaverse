using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    Home,
    Game,
    Score
}

public class TheStackUIManager : MonoBehaviour
{
    static TheStackUIManager instance;

    public static TheStackUIManager Instance
    {
        get { return instance; }
    }

    UIState currentState = UIState.Home;

    TheStackHomeUI homeUI = null;
    TheStackGameUI gameUI = null;
    TheStackScoreUI scoreUI = null;

    TheStack theStack = null;

    private void Awake()
    {
        instance = this;

        theStack = FindObjectOfType<TheStack>();

        homeUI = GetComponentInChildren<TheStackHomeUI>(true);
        homeUI?.Init(this);

        gameUI = GetComponentInChildren<TheStackGameUI>(true);
        gameUI?.Init(this);

        scoreUI = GetComponentInChildren<TheStackScoreUI>(true);
        scoreUI?.Init(this);

        ChangeState(UIState.Home);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        theStack.Restart();
        ChangeState(UIState.Game);
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void UpdateScroe()
    {
        gameUI.SetUI(theStack.Score, theStack.Combo, theStack.MaxCombo);
    }

    public void SetScoreUI()
    {
        scoreUI.SetUI(theStack.Score, theStack.Combo, theStack.BestScore, theStack.BestCombo);

        ChangeState(UIState.Score);
    }
}
