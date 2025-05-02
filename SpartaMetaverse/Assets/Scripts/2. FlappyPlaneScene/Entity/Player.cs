using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region �÷��̾ ����� ���� ����
    Animator animator;
    Rigidbody2D _rigidbody2D;

    public float flapForce = 6.0f;
    public float forwardSpeed = 3.0f;
    public bool isDead = false;

    //  �� ���� �� �÷��̾ �����̴� ���� ���� ���� bool �� ���� ����
    public bool isGameStart = false;
    float deathCoolDown = 0.0f;

    bool isFlap = false;
    #endregion

    public bool godMode = false;

    GameManager gameManager;

    UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        uiManager = UIManager.Instance;

        animator = GetComponentInChildren<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        if(animator == null)
        {
            Debug.LogError("Not Found Animator!!");

        }

        if(_rigidbody2D == null)
        {
            Debug.LogError("Not Found Rigidbody2D!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //  HomeUI���� ���� ���� ��ư�� ���� ������ �÷��̾ �޴� �߷��� 0���� �ξ� �� ����� ���ÿ� ������ ���� ����.
        if (!isGameStart)
        {
            _rigidbody2D.gravityScale = 0.0f;
            forwardSpeed = 0.0f;
            return;
        }

        //  ���� ���� ��ư�� ������ ������ �÷��̾��� �߷��� ����
        else
        {
            _rigidbody2D.gravityScale = 1.0f;
            forwardSpeed = 3.0f;

            //  �׾��� ���� ���� �ʾ��� ���� �����Ͽ� ����
            if (isDead)
            {
                if (deathCoolDown <= 0.0f)
                {
                    ////  ���� �����
                    //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                    //{
                    //    gameManager.RestartGame();
                    //}
                }

                else
                {
                    deathCoolDown -= Time.deltaTime;
                }
            }

            else
            {
                //  ���콺 ������ ��ư�� ���� ���� ������ ��
                if (Input.GetMouseButtonDown(0))
                {
                    //  �÷��̾� ����
                    isFlap = true;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(isDead)
        {
            return;
        }

        else
        {
            Vector2 velocity = _rigidbody2D.velocity;
            velocity.x = forwardSpeed;

            if(isFlap)
            {
                velocity.y += flapForce;
                isFlap = false;
            }

            _rigidbody2D.velocity = velocity;

            //  ���� �� �÷��̾� ������Ʈ�� ȸ����Ŵ
            float angle = Mathf.Clamp((_rigidbody2D.velocity.y * 10.0f), -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(godMode)
        {
            return;
        }

        if(isDead)
        {
            return;
        }

        isDead = true;
        deathCoolDown = 1.0f;

        animator.SetBool("IsDie", true);
        gameManager.GameOver();
    }
}