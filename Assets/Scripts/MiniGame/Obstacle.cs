using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //장애물이 상하로 움직일때 어디까지 움직일지 설정
    public float highPosY = 1f;
    public float lowPosY = -1f;

    //탑과 바닥 장애물 사이의 간격
    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    MiniBoard miniBoard; //미니보드

    private void Start()
    {
        miniBoard = MiniBoard.Instance;
    }

    public Vector2 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        // 홀 사이즈에 따라 장애물의 위치를 설정
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Plane plane = collision.GetComponent<Plane>();
        if (plane != null)
            miniBoard.AddScore(1); // 점수 추가
    }
}
