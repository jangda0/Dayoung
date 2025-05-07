using UnityEngine;

public class Plane : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f; //점프하는 힘
    public float forwardSpeed = 3f; //정면으로 이동하는 힘
    public bool isDead = false; //죽었는지 여부
    float deathCooldown = 0f; //죽었을 때 애니메이션 재생 시간

    bool isFlap = false; //점프했는지 여부

    public bool godMode = false; //모드 확인용

    MiniBoard miniBoard; //미니보드

    // Start is called before the first frame update
    void Start()
    {
        miniBoard = MiniBoard.Instance; //게임 매니저 인스턴스 가져오기

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
                //게임 재시작
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

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);//비행기 각도 조절
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
