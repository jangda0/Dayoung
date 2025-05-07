using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // target = �÷��̾�
    float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x; // ī�޶�� �÷��̾��� x�� �Ÿ�
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX; // ī�޶��� x�� ��ġ�� �÷��̾��� x�� ��ġ�� offsetX ��ŭ ���� ������ ����
        transform.position = pos; // ī�޶��� ��ġ�� ������Ʈ

    }
}
