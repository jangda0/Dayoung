using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;
    public int numBgCount = 5; // 장애물의 개수

    // Start is called before the first frame update
    void Start()
    {
        // 모든 Obstacle 컴포넌트를 가진 게임 오브젝트를 찾아와서 넘겨준다. 
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;

        //모든 obstacle 랜덤 생성하기 
        for (int i = 0; i < obstacles.Length; i++)
        {
            // 장애물의 위치를 설정한다.
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }


    // trigger 충돌되는 아이들도 랜덤배치할 수 있게 해주기. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerd: " + collision.name);

        if (collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            //numBgCount = 개수
            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        // 장애물과 충돌했을 때
        Obstacle obstacle = collision.GetComponent<Obstacle>(); // 'obstacle' 변수 선언 추가
        if (obstacle)
        {
            // 장애물의 위치를 설정한다.
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
