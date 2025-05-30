using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//  로비 화면의 게임 매니저
public class LobbyManager : MonoBehaviour
{
    UIManager uiManager;

    //  게임 내 오브젝트들과의 상호작용에 필요한 변수들 선언
    public TextMeshProUGUI talkText;

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

    #region Awake 메서드
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    #endregion

    #region Action 메서드 → 플레이어와 오브젝트 간 상호작용을 진행할 때 시행되는 메서드
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
   
        uiManager.OnClickObject(isAction);
    }
    #endregion

    #region Talk 메서드 → 오브젝트와 상호작용 시, 대사 데이터를 호출하는 메서드
    //  오브젝트 내 들어있는 텍스트 데이터를 대화창 UI에서 호출한다.
    public void Talk(int id, bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        //  해당 오브젝트에 들어있는 텍스트 데이터가 없을 경우, null을 반환한다.
        if(talkData == null)
        {
            isAction = false;
            return;
        }

        //  bool값이 NPC로 체크되어 있는 오브젝트일 경우, 해당 NPC에 들어있는 텍스트 데이터를 호출!
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