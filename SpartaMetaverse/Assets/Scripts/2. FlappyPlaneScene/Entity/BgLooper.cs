using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;

    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //  GameObject.FindObjectsOfType: <> 안에 있는 타입의 여러 오브젝트들을 탐색하는 함수
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();

        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //  collision.CompareTag: 충돌한 오브젝트의 태그 명을 비교하는 함수
        if (collision.CompareTag("Background"))
        {
            //  이 때, 충돌한 오브젝트를 잠시 BoxCollider2D로 형변환 시킨 후, 사이즈 값을 가져온다.
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;

            //  이미 Background로 처리를 했다면, obstacle이 아니므로 더이상 동작하는 것을 방지하고자 return을 선언한다.
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();

        //  만약 충돌한 오브젝트가 장애물이라면
        if (obstacle)
        {
            //  우리가 알고 있는 장애물이니, 부딪힌 후에 장애물의 위치를 다시 세팅한다.
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
