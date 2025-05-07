using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;
    public int numBgCount = 5; // ��ֹ��� ����

    // Start is called before the first frame update
    void Start()
    {
        // ��� Obstacle ������Ʈ�� ���� ���� ������Ʈ�� ã�ƿͼ� �Ѱ��ش�. 
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;

        //��� obstacle ���� �����ϱ� 
        for (int i = 0; i < obstacles.Length; i++)
        {
            // ��ֹ��� ��ġ�� �����Ѵ�.
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }


    // trigger �浹�Ǵ� ���̵鵵 ������ġ�� �� �ְ� ���ֱ�. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerd: " + collision.name);

        if (collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            //numBgCount = ����
            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        // ��ֹ��� �浹���� ��
        Obstacle obstacle = collision.GetComponent<Obstacle>(); // 'obstacle' ���� ���� �߰�
        if (obstacle)
        {
            // ��ֹ��� ��ġ�� �����Ѵ�.
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
