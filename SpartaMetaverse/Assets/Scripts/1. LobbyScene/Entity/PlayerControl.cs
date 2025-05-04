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

                Debug.Log($"�̰��� �̸��� {scanObject.name} �̴�.");
            }

            else if(!ScanObject())
            {
                Debug.Log("�ƹ��͵� ����");

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

    //  ������ ���� �� Ŭ�� �� ��ȣ�ۿ��� ������Ʈ�� �ִ��� Ȯ���ϴ� �޼���
    bool ScanObject()
    {
        //  ���� ����
        Debug.DrawRay(this.transform.position, lookDirection * 1.3f, new Color(0, 1, 0));

        //  Object Layer ���� ������ �ִ� ������Ʈ�鸸 ��ȣ�ۿ�.
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
