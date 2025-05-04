using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : BaseUI
{
    TextMeshProUGUI dialogueText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        dialogueText = transform.Find("DialogueText").GetComponent<TextMeshProUGUI>();
    }

    protected override UIState GetUIState()
    {
        return UIState.Dialogue;
    }

    public void SetUI(string dialogue)
    {

    }
}
