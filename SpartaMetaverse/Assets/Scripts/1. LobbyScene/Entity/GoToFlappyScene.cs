using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToFlappyScene : MonoBehaviour
{
    //  �浹 ��, �����Ǵ� UIâ ȣ���� ���� UIManager ���� ����.
    UIManager uiManager;

    #region Awake �޼���
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    #endregion

    #region  �÷��̾�� �浹 ��, UIâ�� �����ϴ� �޼���
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
