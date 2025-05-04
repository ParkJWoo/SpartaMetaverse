using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    UIManager uiManager;

    //public GameObject dialougePanel;
    public TextMeshProUGUI talkText;

    public GameObject talkPanel;

    public TalkManager talkManager;
    public int talkIndex;

    //  �÷��̾ ��ĵ�� ������Ʈ
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

    public void Action(GameObject scanObj)
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
            ObjectControl objData = scanObject.GetComponent<ObjectControl>();

            Talk(objData.id, objData.isNPC);
        }

        //talkText.text = "�̰��� �̸��� " + scanObject.name + "��� �Ѵ�.";

        //talkPanel.SetActive(isAction);
        uiManager.OnClickObject(isAction);
    }

    public void Talk(int id, bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            return;
        }

        if(isNPC)
        {
            talkText.text = talkData;

            uiManager.OnClickObject(isAction);
        }

        else
        {
            talkText.text = talkData;

            uiManager.OnClickObject(isAction);
        }

        isAction = true;
        talkIndex++;
    }
}