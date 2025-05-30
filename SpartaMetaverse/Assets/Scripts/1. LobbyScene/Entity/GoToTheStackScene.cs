using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTheStackScene : MonoBehaviour
{
    UIManager uiManager;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //  빌드용 해상도 변경 코드
        Screen.SetResolution(1080, 1920, FullScreenMode.Windowed);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();

        if (player != null)
        {
            uiManager.ChangeState(UIState.EnterMiniGame);

            SceneManager.LoadScene("TheStackScene");
        }
    }
}
