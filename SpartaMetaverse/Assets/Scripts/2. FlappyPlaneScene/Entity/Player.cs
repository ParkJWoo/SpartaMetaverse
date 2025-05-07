using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 플레이어가 사용할 변수 선언
    Animator animator;
    Rigidbody2D _rigidbody2D;

    public float flapForce = 6.0f;
    public float forwardSpeed = 3.0f;
    public bool isDead = false;

    //  씬 입장 시 플레이어가 움직이는 것을 막기 위한 bool 값 변수 선언
    public bool isGameStart = false;
    float deathCoolDown = 0.0f;

    bool isFlap = false;
    #endregion

    public bool godMode = false;

    GameManager gameManager;

    UIManager uiManager;

    #region Start 메서드 
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
    #endregion

    #region Update 메서드 → 게임 화면 전환 시, 플레이어가 자동으로 떨어지지 않도록 구현 + 플레이어 사망 처리 등을 관리한다.
    void Update()
    {
        //  HomeUI에서 게임 시작 버튼을 누를 때까지 플레이어가 받는 중력을 0으로 두어 씬 입장과 동시에 끝나는 것을 방지.
        if (!isGameStart)
        {
            _rigidbody2D.gravityScale = 0.0f;
            forwardSpeed = 0.0f;
            return;
        }

        //  게임 시작 버튼을 눌렀을 때부터 플레이어의 중력을 적용
        else
        {
            _rigidbody2D.gravityScale = 1.0f;
            forwardSpeed = 3.0f;

            //  죽었을 때와 죽지 않았을 때를 구분하여 동작
            if (isDead)
            {
                if (deathCoolDown <= 0.0f)
                {
                   
                }

                else
                {
                    deathCoolDown -= Time.deltaTime;
                }
            }

            else
            {
                //  마우스 왼쪽 버튼을 누를 때만 점프를 뜀
                if (Input.GetMouseButtonDown(0))
                {
                    //  플레이어 점프
                    isFlap = true;
                }
            }
        }
    }
    #endregion

    #region FixedUpdate 메서드 → 마우스 클릭 시, 점프 적용을 관리한다.
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

            //  점프 시 플레이어 오브젝트를 회전시킴
            float angle = Mathf.Clamp((_rigidbody2D.velocity.y * 10.0f), -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    #endregion

    #region 장애물과 충돌 시 플레이어 사망 처리를 담당하는 구간
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
    #endregion
}