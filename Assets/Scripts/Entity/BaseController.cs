using System;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    //Serializefield로 다른 스크립트에서 접근할 수 있도록 설정
    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weaponPivot;

    //이동할 방향과 바라볼 방향을 저장하는 변수. 
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;

    public Vector2 LookDirection { get { return lookDirection; } }

    private Vector2 knockback = Vector2.zero;//knockback의 방향을
    private float knockbackDurantion = 0.0f;// knockback의 지속시간. 

    protected StatHandler statHandler;
    protected AnimationHandler animationHandler;//애니메이션 핸들러를 상속받아 사용하기 위해서.

    [SerializeField] public WeaponHandler WeaponPrefab;
    protected WeaponHandler weaponHandler;

    protected bool isAttacking;
    private float timeSinceLastAttack = float.MaxValue;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();

        if(WeaponPrefab != null)
            weaponHandler = Instantiate(WeaponPrefab, weaponPivot);
        else
            weaponHandler = GetComponentInChildren<WeaponHandler>();
    }

    //베이스 컨트롤러는 상속받아 사용할 예정임으로 virtual로 설정
    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();//입력처리, 입력이 필요한 데이터 처리. 
        Rotate(lookDirection);//회전 
        HandleAttackDelay();
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);//이동처리.
        if (knockbackDurantion > 0.0f)
        {
            knockbackDurantion -= Time.fixedDeltaTime;
        }
    }

    protected virtual void HandleAction()
    {

    }

    private void Movement(Vector2 direction)
    {
        direction = direction * statHandler.Speed;
        if (knockbackDurantion > 0.0f)//knockbackDurantion이 남아있다면. 
        {
            direction *= 0.2f;//knockback이 남아있다면 이동속도를 줄여주고
            direction += knockback; //knockback의 힘만 더해준다. 
        }
        _rigidbody.velocity = direction;//이동속도 설정. 
        animationHandler.Move(direction);//애니메이션 핸들러에 이동속도 전달.
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;//왼쪽으로 회전하는지 확인.

        if (weaponPivot != null)
        {
            weaponPivot.localRotation = Quaternion.Euler(0, 0, rotZ);
        }

        weaponHandler?.Rotate(isLeft);//무기 회전.
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDurantion = duration;
        knockback = -(other.position - transform.position).normalized * power;
    }

    private void HandleAttackDelay()
    {
        if (weaponHandler == null)
            return;

        if(timeSinceLastAttack <= weaponHandler.Delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        if (isAttacking && timeSinceLastAttack > weaponHandler.Delay)
        {
            timeSinceLastAttack = 0;
            Attack();
        }
    }

    protected virtual void Attack()
    {
            Debug.Log("Attack");
        if(lookDirection != Vector2.zero)
        {
            Debug.Log("Attack_1");
            weaponHandler?.Attack();
        }
    }

    public virtual void Death()
    {
        _rigidbody.velocity = Vector3.zero;

        foreach(SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = renderer.color;
            color.a = 0.3f;
            renderer.color = color;
        }

        foreach(Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        {
            component.enabled = false;
        }

        Destroy(gameObject, 2f);
    }
}
