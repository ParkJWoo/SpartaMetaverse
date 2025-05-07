using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//  �κ� ȭ���� ���� �Ŵ���
public class LobbyManager : MonoBehaviour
{
    UIManager uiManager;

    //  ���� �� ������Ʈ����� ��ȣ�ۿ뿡 �ʿ��� ������ ����
    public TextMeshProUGUI talkText;

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

    #region Awake �޼���
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    #endregion

    #region Action �޼��� �� �÷��̾�� ������Ʈ �� ��ȣ�ۿ��� ������ �� ����Ǵ� �޼���
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
   
        uiManager.OnClickObject(isAction);
    }
    #endregion

    #region Talk �޼��� �� ������Ʈ�� ��ȣ�ۿ� ��, ��� �����͸� ȣ���ϴ� �޼���
    //  ������Ʈ �� ����ִ� �ؽ�Ʈ �����͸� ��ȭâ UI���� ȣ���Ѵ�.
    public void Talk(int id, bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        //  �ش� ������Ʈ�� ����ִ� �ؽ�Ʈ �����Ͱ� ���� ���, null�� ��ȯ�Ѵ�.
        if(talkData == null)
        {
            isAction = false;
            return;
        }

        //  bool���� NPC�� üũ�Ǿ� �ִ� ������Ʈ�� ���, �ش� NPC�� ����ִ� �ؽ�Ʈ �����͸� ȣ��!
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
    }
    #endregion
}