using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyPlaneUIManager : MonoBehaviour
{
    public Text scoreText;
    public Text restartText;

    // Start is called before the first frame update
    void Start()
    {
        if(restartText == null)
        {
            Debug.LogError("Restart Text is null");
        }

        if(scoreText == null)
        {
            Debug.LogError("Score Text is null");
        }

        restartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
  
}
