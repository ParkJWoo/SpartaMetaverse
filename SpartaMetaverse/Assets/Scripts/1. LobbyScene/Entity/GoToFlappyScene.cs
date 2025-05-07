using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToFlappyScene : MonoBehaviour
{
    //  충돌 시, 생성되는 UI창 호출을 위한 UIManager 변수 선언.
    UIManager uiManager;

    #region Awake 메서드
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    #endregion

    #region  플레이어와 충돌 시, UI창을 생성하는 메서드
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();

        if (player != null)
        {
            uiManager.OnTriggerEnterMiniGameUI();
        }
    }
    #endregion
}
