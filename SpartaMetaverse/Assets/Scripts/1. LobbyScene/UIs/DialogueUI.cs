using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : BaseUI
{
    TextMeshProUGUI dialogueText;
    GameObject scanObject;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        dialogueText = transform.Find("DialogueText").GetComponent<TextMeshProUGUI>();
    }

    protected override UIState GetUIState()
    {
        return UIState.Dialogue;
    }

    //  �� ������Ʈ �� ����ִ� ��縦 �����Ѵ�.
    public void SetUI(GameObject scanObj, string talkData)
    {
        scanObject = scanObj;

        dialogueText.text = talkData;
    }
}