using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //��ֹ��� ���Ϸ� �����϶� ������ �������� ����
    public float highPosY = 1f;
    public float lowPosY = -1f;

    //ž�� �ٴ� ��ֹ� ������ ����
    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    MiniBoard miniBoard; //�̴Ϻ���

    private void Start()
    {
        miniBoard = MiniBoard.Instance;
    }

    public Vector2 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        // Ȧ ����� ���� ��ֹ��� ��ġ�� ����
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
            miniBoard.AddScore(1); // ���� �߰�
    }
}
