using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UIState
{
    None,
    Dialogue,
    EnterMiniGame,
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

    UIState currentState = UIState.None;

    EnterMiniGameUI enterMiniGameUI = null;
    DialogueUI dialogueUI = null;
    HomeUI homeUI = null;
    GameUI gameUI = null;
    GameOverUI gameOverUI = null;

    GameManager gameManager;
    LobbyManager lobbyManager;

    private void Awake()
    {
        instance = this;

        gameManager = FindObjectOfType<GameManager>();

        lobbyManager = FindObjectOfType<LobbyManager>();

        enterMiniGameUI = GetComponentInChildren<EnterMiniGameUI>(true);
        enterMiniGameUI?.Init(this);

        dialogueUI = GetComponentInChildren<DialogueUI>();
        dialogueUI?.Init(this);

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
        enterMiniGameUI?.SetActive(currentState);
        dialogueUI?.SetActive(currentState);
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        gameOverUI?.SetActive(currentState);
    }

    //  플레이어가 미니 게임 입장 UI에서 "아니오" 버튼을 누를 시, 해당 UI를 닫음
    public void UIStateNone()
    {
        ChangeState(UIState.None);
    }

    //  플레이어가 미니 게임 지점에 도달했을 시, 미니 게임 입장 UI 생성
    public void OnTriggerEnterMiniGameUI()
    {
        ChangeState(UIState.EnterMiniGame);
    }

    //  오브젝트와 상호작용 시, 대화창 UI 생성
    public void OnClickObject(bool isAction)
    {
        ChangeState(UIState.Dialogue);

        if(isAction)
        {
            dialogueUI.SetUI(lobbyManager.scanObject, lobbyManager.talkText.text);
        }

        else if(!isAction)
        {
            ChangeState(UIState.None);
        }

    }

    //  미니 게임 입장 UI에서 "예" 버튼을 누를 시, 미니 게임 화면으로 이동
    public void OnClickEnterMiniGame()
    {
        SceneManager.LoadScene("FlappyPlaneScene");

        ChangeState(UIState.Home);
    }

    //  미니 게임 씬 → 나가기 버튼 누를 시, 로비 씬으로 이동
    public void OnClickExit()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void OnClickStart()
    {
        Player player = FindObjectOfType<Player>();

        player.isGameStart = true;

        ChangeState(UIState.Game);
    }

    public void OnClickRestart()
    {
        ChangeState(UIState.Game);
    }

    //  로비 씬 → 나가기 버튼 누를 시 게임 종료
    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
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
