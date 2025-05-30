using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region 프로젝트 내 모든 UI들을 enum화를 통해 관리한다.
public enum UIState
{
    None,
    Dialogue,
    EnterMiniGame,
    Home,
    Game,
    GameOver
}
#endregion

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

    #region Awake 메서드 → 모든 UI들을 초기화하기 위한 메서드
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
    #endregion

    #region ChangeState 메서드 → 각각의 UI들의 생성 조건을 충족할 경우, 조건을 충족한 UI들의 Active 상태를 true로 전환한다.
    public void ChangeState(UIState state)
    {
        currentState = state;
        enterMiniGameUI?.SetActive(currentState);
        dialogueUI?.SetActive(currentState);
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        gameOverUI?.SetActive(currentState);
    }
    #endregion

    #region UI 디폴트 상태 → None 상태로 전환한 후, 각각의 UI들의 생성 조건을 충족할 때, 해당 UI의 상태로 전환한다. 
    //  플레이어가 미니 게임 입장 UI에서 "아니오" 버튼을 누를 시, 해당 UI를 닫음
    public void UIStateNone()
    {
        ChangeState(UIState.None);
    }
    #endregion

    #region 미니 게임 UI 생성 메서드
    //  플레이어가 미니 게임 지점에 도달했을 시, 미니 게임 입장 UI 생성
    public void OnTriggerEnterMiniGameUI()
    {
        ChangeState(UIState.EnterMiniGame);
    }
    #endregion

    #region 대화창 UI 생성 메서드
    //  오브젝트와 상호작용 시, 대화창 UI 생성
    //  게임 시작 전, 유니티 에디터에서 대화창 UI를 킨 상태에서만 적용됨 → 끄고 할 경우, 해당 구간에 에러 발생 및 UI창이 켜지지 않음 (원인 불명)
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
    #endregion

    #region 미니 게임 입정 UI → 예 버튼의 이벤트 처리 메서드
    //  미니 게임 입장 UI에서 "예" 버튼을 누를 시, 미니 게임 화면으로 이동
    public void OnClickEnterMiniGame()
    {
        SceneManager.LoadScene("FlappyPlaneScene");

        ChangeState(UIState.Home);
    }
    #endregion

    #region 미니 게임 씬 → 입장 시 생성되는 UI 내 시작, 재시작, 나가기 버튼 이벤트 처리 메서드
    public void OnClickStart()
    {
        Player player = FindObjectOfType<Player>();

        player.isGameStart = true;

        ChangeState(UIState.Game);
    }

    //  미니 게임 씬 → 나가기 버튼 누를 시, 로비 씬으로 이동
    public void OnClickExit()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void OnClickRestart()
    {
        ChangeState(UIState.Game);
    }

    #endregion

    #region 로비 씬 → 나가기 버튼을 누를 시 이벤트 처리 메서드 (현재 로비 씬에 해당 UI는 존재하지 않음)
    //  로비 씬 → 나가기 버튼 누를 시 게임 종료
    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
    #endregion

    #region 미니 게임 씬 → 점수 기록 이벤트 처리 메서드
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
    #endregion
}
