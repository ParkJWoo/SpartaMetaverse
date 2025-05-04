using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : BaseUI
{
    TextMeshProUGUI talkText;

    GameObject scanObject;
    bool isAction;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        talkText = transform.Find("DialogueText").GetComponent<TextMeshProUGUI>();
    }

    protected override UIState GetUIState()
    {
        return UIState.Dialogue;
    }

    public void OnClickNPC(bool action, GameObject scanObj)
    {
        scanObject = scanObj;

        talkText.text = "이것의 이름은 " + scanObject.name + "라고 한다.";
    }
}
