using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UIState
{
    Home,
    Game,
    GameOver
}

public class UIManager : MonoBehaviour
{
    static UIManager instance;

    public static UIManager Instance
    {
        get { return instance; }
    }

    UIState currentState = UIState.Home;

    HomeUI homeUI = null;
    GameUI gameUI = null;
    GameOverUI gameOverUI = null;

    GameManager gameManager;

    private void Awake()
    {
        instance = this;

        gameManager = FindObjectOfType<GameManager>();

        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI?.Init(this);

        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI?.Init(this);

        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI?.Init(this);

        ChangeState(UIState.Home);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        gameOverUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        ChangeState(UIState.Game);
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    //  로비 씬 → 나가기 버튼 누를 시 게임 종료
    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        //Application.Quit();
    }

    public void UpdateScroe()
    {
        gameUI.SetUI(gameManager.Score);

        if(gameManager.bestScore < gameManager.Score)
        {
            gameManager.bestScore = gameManager.Score;

            PlayerPrefs.SetInt(gameManager.BestScoreKey, gameManager.bestScore);
        }
    }

    public void SetScoreUI()
    {
        gameOverUI.SetUI(gameManager.Score, gameManager.bestScore);

        ChangeState(UIState.GameOver);
    }
}
