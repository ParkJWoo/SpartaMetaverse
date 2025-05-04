using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//  로비 화면의 게임 매니저
public class LobbyManager : MonoBehaviour
{
    UIManager uiManager;

    //  상호작용에 필요한 변수들 선언
    public TextMeshProUGUI talkText;

    public GameObject talkPanel;

    public TalkManager talkManager;
    public int talkIndex;

    //  플레이어가 스캔한 오브젝트
    public GameObject scanObject;

    //  오브젝트와 상호작용 시, 플레이어의 행동을 제어하기 위한 변수
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

        //  오브젝트와 상호작용이 성공했다면, 대화창 UI 생성과 대사 데이터들을 호출한다.
        else
        {
            isAction = true;

            scanObject = scanObj;
            ObjectControl objData = scanObject.GetComponent<ObjectControl>();

            Talk(objData.id, objData.isNPC);
        }

        //talkText.text = "이것의 이름은 " + scanObject.name + "라고 한다.";

        //talkPanel.SetActive(isAction);
        uiManager.OnClickObject(isAction);
    }

    //  오브젝트 내 들어있는 대사 데이터를 대화창 UI에서 호출한다.
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