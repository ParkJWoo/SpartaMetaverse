using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : BaseControl
{
    private Camera camera;
    public GameObject scanObject;

    public LobbyManager manager;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetMouseButtonDown(0))
        {
            if(ScanObject())
            {
                manager.Action(scanObject);

                Debug.Log($"이것의 이름은 {scanObject.name} 이다.");
            }

            else if(!ScanObject())
            {
                Debug.Log("아무것도 없다");

            }
        }

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        ScanObject();
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }

        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    //  지정한 범위 내 클릭 시 상호작용할 오브젝트가 있는지 확인하는 메서드
    bool ScanObject()
    {
        //  범위 설정
        Debug.DrawRay(this.transform.position, lookDirection * 1.3f, new Color(0, 1, 0));

        //  Object Layer 값을 가지고 있는 오브젝트들만 상호작용.
        RaycastHit2D rayHit = Physics2D.Raycast(this.transform.position, lookDirection, 1.3f, 1 << LayerMask.NameToLayer("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;

            return true;
        }

        else
        {
            scanObject = null;

            return false;
        }
    }
}
