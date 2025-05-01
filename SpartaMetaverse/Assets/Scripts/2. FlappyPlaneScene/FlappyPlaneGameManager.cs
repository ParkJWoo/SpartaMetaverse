using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlaneGameManager : MonoBehaviour
{
    //  �̱����� ���� �� ���� �⺻���� ����
    static FlappyPlaneGameManager gameManager;

    //  Instanceȭ�� ���� �ش� ��ü�� ���� ������ �� �ֵ��� �Ѵ�.
    public static FlappyPlaneGameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0;

    FlappyPlaneUIManager uiManager;

    public FlappyPlaneUIManager UIManager
    {
        get { return uiManager; }
    }

    public void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<FlappyPlaneUIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over!!");

        uiManager.SetRestart();
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

        uiManager.UpdateScore(currentScore);
    }
}
