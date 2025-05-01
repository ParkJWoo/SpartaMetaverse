using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToFlappyScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();

        if (player != null)
        {
            SceneManager.LoadScene("FlappyPlaneScene");
        }
    }
}
