using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    UIManager uiManager;

    public TextMeshProUGUI talkText;

    //  �÷��̾ ��ĵ�� ������Ʈ
    public GameObject scanObject;

    public UIManager UIManager
    {
        get { return uiManager; }
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;

        talkText.text = "�̰��� �̸��� " + scanObject.name + "��� �Ѵ�.";
    }

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
