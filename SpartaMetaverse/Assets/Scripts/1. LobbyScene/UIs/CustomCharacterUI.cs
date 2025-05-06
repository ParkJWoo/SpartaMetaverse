using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomCharacterUI : BaseUI
{
    Button customColorButton;
    Button customWeaponButton;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        customColorButton = transform.Find("CustomColorButton").GetComponent<Button>();
        customWeaponButton = transform.Find("CustomWeaponButton").GetComponent<Button>();

        customColorButton.onClick.AddListener(OnClickCustomColorButton);
        customWeaponButton.onClick.AddListener(OnClickCustomWeapon);
    }

    protected override UIState GetUIState()
    {
        return UIState.CustomCharacter;
    }

    void OnClickCustomColorButton()
    {

    }

    void OnClickCustomWeapon()
    {

    }
}
