using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : BaseControl
{
    private Camera camera;
    public GameObject scanObject;

    public LobbyManager manager;

    #region Start 메서드
    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }
    #endregion

    #region Update 메서드
    protected override void Update()
    {
        base.Update();

        if(Input.GetMouseButtonDown(0))
        {
            if(scanObject != null)
            {
                manager.Action(scanObject);
            }

            else
            {
                manager.Action(scanObject);
            }
        }
    }
    #endregion

    #region FixedUpdate 메서드 → ScanObject 메서드 추가
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        ScanObject();
    }
    #endregion

    #region HandleAction 메서드
    protected override void HandleAction()
    {
        float horizontal = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        float vertical = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = manager.isAction ? Vector2.zero : (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }

        else
        {
            lookDirection = lookDirection.normalized;
        }
    }
    #endregion

    #region ScanObject 메서드 → 추가한 기능
    //  지정한 범위 내 클릭 시 상호작용할 오브젝트가 있는지 확인하는 메서드
    void ScanObject()
    {
        //  범위 설정
        Debug.DrawRay(this.transform.position, lookDirection * 1.3f, new Color(0, 1, 0));

        //  Object Layer 값을 가지고 있는 오브젝트들만 상호작용.
        RaycastHit2D rayHit = Physics2D.Raycast(this.transform.position, lookDirection, 1.3f, 1 << LayerMask.NameToLayer("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }

        else
        {
            scanObject = null;
        }
    }
    #endregion
}
