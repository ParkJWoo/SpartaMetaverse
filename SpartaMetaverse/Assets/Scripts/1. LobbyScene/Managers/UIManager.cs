using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region ������Ʈ �� ��� UI���� enumȭ�� ���� �����Ѵ�.
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

    #region Awake �޼��� �� ��� UI���� �ʱ�ȭ�ϱ� ���� �޼���
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

    #region ChangeState �޼��� �� ������ UI���� ���� ������ ������ ���, ������ ������ UI���� Active ���¸� true�� ��ȯ�Ѵ�.
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

    #region UI ����Ʈ ���� �� None ���·� ��ȯ�� ��, ������ UI���� ���� ������ ������ ��, �ش� UI�� ���·� ��ȯ�Ѵ�. 
    //  �÷��̾ �̴� ���� ���� UI���� "�ƴϿ�" ��ư�� ���� ��, �ش� UI�� ����
    public void UIStateNone()
    {
        ChangeState(UIState.None);
    }
    #endregion

    #region �̴� ���� UI ���� �޼���
    //  �÷��̾ �̴� ���� ������ �������� ��, �̴� ���� ���� UI ����
    public void OnTriggerEnterMiniGameUI()
    {
        ChangeState(UIState.EnterMiniGame);
    }
    #endregion

    #region ��ȭâ UI ���� �޼���
    //  ������Ʈ�� ��ȣ�ۿ� ��, ��ȭâ UI ����
    //  ���� ���� ��, ����Ƽ �����Ϳ��� ��ȭâ UI�� Ų ���¿����� ����� �� ���� �� ���, �ش� ������ ���� �߻� �� UIâ�� ������ ���� (���� �Ҹ�)
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

    #region �̴� ���� ���� UI �� �� ��ư�� �̺�Ʈ ó�� �޼���
    //  �̴� ���� ���� UI���� "��" ��ư�� ���� ��, �̴� ���� ȭ������ �̵�
    public void OnClickEnterMiniGame()
    {
        SceneManager.LoadScene("FlappyPlaneScene");

        ChangeState(UIState.Home);
    }
    #endregion

    #region �̴� ���� �� �� ���� �� �����Ǵ� UI �� ����, �����, ������ ��ư �̺�Ʈ ó�� �޼���
    public void OnClickStart()
    {
        Player player = FindObjectOfType<Player>();

        player.isGameStart = true;

        ChangeState(UIState.Game);
    }

    //  �̴� ���� �� �� ������ ��ư ���� ��, �κ� ������ �̵�
    public void OnClickExit()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void OnClickRestart()
    {
        ChangeState(UIState.Game);
    }

    #endregion

    #region �κ� �� �� ������ ��ư�� ���� �� �̺�Ʈ ó�� �޼��� (���� �κ� ���� �ش� UI�� �������� ����)
    //  �κ� �� �� ������ ��ư ���� �� ���� ����
    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
    #endregion

    #region �̴� ���� �� �� ���� ��� �̺�Ʈ ó�� �޼���
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
