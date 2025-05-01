using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //  �̱����� ���� �� ���� �⺻���� ����
    static GameManager gameManager;

    //  Instanceȭ�� ���� �ش� ��ü�� ���� ������ �� �ֵ��� �Ѵ�.
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
    //public int BestScore { get => bestScore; set => bestScore; }

    public string BestScoreKey = "BestScore";

    public void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScroe();

        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over!!");

        uiManager.SetScoreUI();
    }

    public void RestartGame()
    {
        //  ���� ���� �ִ� ���� �̸��� ȣ���� �ҷ��´�.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);

        uiManager.UpdateScroe();
    }
}
