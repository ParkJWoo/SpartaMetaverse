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

    public void SetUI(GameObject scanObj, string talkData)
    {
        scanObject = scanObj;

        //dialogueText.text = $"이것의 이름은 {scanObject.name} 이다";

        dialogueText.text = talkData;
    }
}