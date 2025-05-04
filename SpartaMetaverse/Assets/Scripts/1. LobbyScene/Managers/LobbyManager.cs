using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    UIManager uiManager;

    public GameObject dialougePanel;
    public TextMeshProUGUI talkText;

    //  플레이어가 스캔한 오브젝트
    public GameObject scanObject;

    public bool isAction;

    public UIManager UIManager
    {
        get { return uiManager; }
    }
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void InteractiveAction(GameObject scanObj)
    {
        //  Exit Action
        if (isAction)
        {
            isAction = false;
        }

        //  Enter Action
        else
        {
            isAction = true;
            scanObject = scanObj;
        }

        UIManager.OnClickObject(isAction);
    }
}
