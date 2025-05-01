using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlaneGameManager : MonoBehaviour
{
    //  싱글톤을 만들 때 가장 기본적인 형태
    static FlappyPlaneGameManager gameManager;

    //  Instance화를 통해 해당 객체를 쉽게 참조할 수 있도록 한다.
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
        //  현재 켜져 있는 씬의 이름을 호출해 불러온다.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);

        uiManager.UpdateScore(currentScore);
    }
}
