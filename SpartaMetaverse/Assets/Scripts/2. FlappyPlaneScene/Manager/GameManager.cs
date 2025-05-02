using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //  싱글톤을 만들 때 가장 기본적인 형태
    static GameManager gameManager;

    //  Instance화를 통해 해당 객체를 쉽게 참조할 수 있도록 한다.
    public static GameManager Instance
    {
        get { return gameManager; }
    }

    UIManager uiManager;

    public UIManager UIManager
    {
        get { return uiManager; }
    }

    private int currentScore = 0;
    public int Score { get { return currentScore; } }

    public int bestScore = 0;

    public string BestScoreKey = "BestScore";

    public void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        //Restart();
        uiManager.UpdateScroe();

        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    public void GameOver()
    {
        uiManager.SetScoreUI();
    }

    public void RestartGame()
    {
        //  현재 켜져 있는 씬의 이름을 호출해 불러온다.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        uiManager.UIStateNone();
    }

    public void AddScore(int score)
    {
        currentScore += score;

        uiManager.UpdateScroe();
    }

    public void Restart()
    {
        //  게임 씬에 입장하자마자 플레이어가 움직이는 것을 막기 위한 용도
        Player player = GetComponent<Player>();

        player.isDead = false;
        player.forwardSpeed = 0.0f;
    }
}