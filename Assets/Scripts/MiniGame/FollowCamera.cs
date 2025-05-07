using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // target = 플레이어
    float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x; // 카메라와 플레이어의 x축 거리
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX; // 카메라의 x축 위치를 플레이어의 x축 위치에 offsetX 만큼 더한 값으로 설정
        transform.position = pos; // 카메라의 위치를 업데이트

    }
}
