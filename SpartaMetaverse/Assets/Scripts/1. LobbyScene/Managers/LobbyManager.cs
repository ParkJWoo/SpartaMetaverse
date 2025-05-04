using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    UIManager uiManager;

    public TextMeshProUGUI talkText;

    //  플레이어가 스캔한 오브젝트
    public GameObject scanObject;

    public UIManager UIManager
    {
        get { return uiManager; }
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;

        talkText.text = "이것의 이름은 " + scanObject.name + "라고 한다.";
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
