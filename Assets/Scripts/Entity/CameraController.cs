using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 cameraPosition;

    [SerializeField] private Vector2 center;
    [SerializeField] private Vector2 mapSize;

    [SerializeField]
    float cameraMoveSpeed;
    float cameraHeight;
    float cameraWidth;


    private void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogWarning("Player Transform�� �Ҵ���� �ʾҽ��ϴ�. �ڵ����� ã���ϴ�.");
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                playerTransform = player.transform;
            else
                Debug.LogError("Player�� ã�� �� �����ϴ�. �±� Ȯ�� �ʿ�.");
        }

        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (playerTransform == null) return;

        Vector3 targetPosition = playerTransform.position + cameraPosition;

        // �� ���� ����
        float limitX = Mathf.Clamp(targetPosition.x, center.x - (mapSize.x - cameraWidth), center.x + (mapSize.x - cameraWidth));
        float limitY = Mathf.Clamp(targetPosition.y, center.y - (mapSize.y - cameraHeight), center.y + (mapSize.y - cameraHeight));

        Vector3 clampedPosition = new Vector3(limitX, limitY, cameraPosition.z);

        // �ε巴�� �̵�
        transform.position = Vector3.Lerp(transform.position, clampedPosition, Time.deltaTime * cameraMoveSpeed);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }
#endif
}
