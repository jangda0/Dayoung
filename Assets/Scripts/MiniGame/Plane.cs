using UnityEngine;

public class Plane : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f; //�����ϴ� ��
    public float forwardSpeed = 3f; //�������� �̵��ϴ� ��
    public bool isDead = false; //�׾����� ����
    float deathCooldown = 0f; //�׾��� �� �ִϸ��̼� ��� �ð�

    bool isFlap = false; //�����ߴ��� ����

    public bool godMode = false; //��� Ȯ�ο�

    MiniBoard miniBoard; //�̴Ϻ���

    // Start is called before the first frame update
    void Start()
    {
        miniBoard = MiniBoard.Instance; //���� �Ŵ��� �ν��Ͻ� ��������

        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.LogError("Not Founded Animator");

        if (_rigidbody == null)
            Debug.LogError("Not Founded Rigidbody2D");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                //���� �����
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    miniBoard.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (isDead) return;
        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }
        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);//����� ���� ����
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("IsDie", 1);
        miniBoard.GameOver();
    }
}
