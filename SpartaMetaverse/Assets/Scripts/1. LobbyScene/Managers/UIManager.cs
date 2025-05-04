using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UIState
{
    None,
    Dialogue,
    CustomCharacter,
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

    DialogueUI dialogueUI = null;
    CustomCharacterUI customCharacterUI = null;
    EnterMiniGameUI enterMiniGameUI = null;
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

        dialogueUI = GetComponentInChildren<DialogueUI>();
        dialogueUI?.Init(this);

        customCharacterUI = GetComponentInChildren<CustomCharacterUI>();
        customCharacterUI?.Init(this);

        enterMiniGameUI = GetComponentInChildren<EnterMiniGameUI>(true);
        enterMiniGameUI?.Init(this);

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
        customCharacterUI.SetActive(currentState);
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        gameOverUI?.SetActive(currentState);
    }

    //  �÷��̾ �̴� ���� ���� UI���� "�ƴϿ�" ��ư�� ���� ��, �ش� UI�� ����
    public void UIStateNone()
    {
        ChangeState(UIState.None);
    }

    //  �÷��̾ �̴� ���� ������ �������� ��, �̴� ���� ���� UI ����
    public void OnTriggerEnterMiniGameUI()
    {
        ChangeState(UIState.EnterMiniGame);
    }

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

    public void OnTriggerCustomCharacter()
    {
        ChangeState(UIState.CustomCharacter);
    }

    public void OnClickCustomColor()
    {

    }

    //  �̴� ���� ���� UI���� "��" ��ư�� ���� ��, �̴� ���� ȭ������ �̵�
    public void OnClickEnterMiniGame()
    {
        SceneManager.LoadScene("FlappyPlaneScene");

        ChangeState(UIState.Home);
    }

    //  �̴� ���� �� �� ������ ��ư ���� ��, �κ� ������ �̵�
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

    //  �κ� �� �� ������ ��ư ���� �� ���� ����
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
