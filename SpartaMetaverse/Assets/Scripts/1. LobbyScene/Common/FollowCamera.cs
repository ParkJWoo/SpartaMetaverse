using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;               //  따라다닐 플레이어 오브젝트
    public float followSpeed = 4.0f;        //  따라가는 속도
    public float z = -10.0f;                //  z축 고정

    Transform cameraTransform;
    Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        targetTransform = target.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.position = Vector2.Lerp(cameraTransform.position, targetTransform.position, followSpeed * Time.deltaTime);

        cameraTransform.Translate(0, 0, z);
    }
}