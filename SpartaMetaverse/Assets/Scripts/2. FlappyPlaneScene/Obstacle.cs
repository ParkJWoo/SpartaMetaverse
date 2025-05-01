using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1.0f;
    public float lowPosY = -1.0f;

    //  위와 아래 장애물 사이의 간격
    public float holeSizeMin = 1.0f;
    public float holeSizeMax = 3.0f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4.0f;

    FlappyPlaneGameManager gameManager;

    private void Start()
    {
        gameManager = FlappyPlaneGameManager.Instance;
    }

    public Vector2 SetRandomPlace(Vector2 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMax, holeSizeMin);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector2(0, halfHoleSize);
        bottomObject.localPosition = new Vector2(0, -halfHoleSize);

        Vector2 placePosition = lastPosition + new Vector2(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            gameManager.AddScore(1);
        }
    }
}