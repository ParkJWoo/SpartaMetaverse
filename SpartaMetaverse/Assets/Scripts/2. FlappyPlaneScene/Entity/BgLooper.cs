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
        //  GameObject.FindObjectsOfType: <> �ȿ� �ִ� Ÿ���� ���� ������Ʈ���� Ž���ϴ� �Լ�
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
        //  collision.CompareTag: �浹�� ������Ʈ�� �±� ���� ���ϴ� �Լ�
        if (collision.CompareTag("Background"))
        {
            //  �� ��, �浹�� ������Ʈ�� ��� BoxCollider2D�� ����ȯ ��Ų ��, ������ ���� �����´�.
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;

            //  �̹� Background�� ó���� �ߴٸ�, obstacle�� �ƴϹǷ� ���̻� �����ϴ� ���� �����ϰ��� return�� �����Ѵ�.
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();

        //  ���� �浹�� ������Ʈ�� ��ֹ��̶��
        if (obstacle)
        {
            //  �츮�� �˰� �ִ� ��ֹ��̴�, �ε��� �Ŀ� ��ֹ��� ��ġ�� �ٽ� �����Ѵ�.
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
