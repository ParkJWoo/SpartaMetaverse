using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//  �κ� ȭ���� ���� �Ŵ���
public class LobbyManager : MonoBehaviour
{
    UIManager uiManager;

    //  ��ȣ�ۿ뿡 �ʿ��� ������ ����
    public TextMeshProUGUI talkText;

    public GameObject talkPanel;

    public TalkManager talkManager;
    public int talkIndex;

    //  �÷��̾ ��ĵ�� ������Ʈ
    public GameObject scanObject;

    //  ������Ʈ�� ��ȣ�ۿ� ��, �÷��̾��� �ൿ�� �����ϱ� ���� ����
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
        if (isAction)
        {
            isAction = false;
        }

        //  ������Ʈ�� ��ȣ�ۿ��� �����ߴٸ�, ��ȭâ UI ������ ��� �����͵��� ȣ���Ѵ�.
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

    //  ������Ʈ �� ����ִ� ��� �����͸� ��ȭâ UI���� ȣ���Ѵ�.
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