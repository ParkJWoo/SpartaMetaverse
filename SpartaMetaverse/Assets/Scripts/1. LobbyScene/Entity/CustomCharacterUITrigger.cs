using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterUITrigger : MonoBehaviour
{
    UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();

        if (player != null)
        {
            uiManager.OnTriggerCustomCharacter();
        }
    }
}
