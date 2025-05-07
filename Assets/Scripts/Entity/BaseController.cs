using System;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    //Serializefield�� �ٸ� ��ũ��Ʈ���� ������ �� �ֵ��� ����
    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weaponPivot;

    //�̵��� ����� �ٶ� ������ �����ϴ� ����. 
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;

    public Vector2 LookDirection { get { return lookDirection; } }

    private Vector2 knockback = Vector2.zero;//knockback�� ������
    private float knockbackDurantion = 0.0f;// knockback�� ���ӽð�. 

    protected StatHandler statHandler;
    protected AnimationHandler animationHandler;//�ִϸ��̼� �ڵ鷯�� ��ӹ޾� ����ϱ� ���ؼ�.

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

    //���̽� ��Ʈ�ѷ��� ��ӹ޾� ����� ���������� virtual�� ����
    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();//�Է�ó��, �Է��� �ʿ��� ������ ó��. 
        Rotate(lookDirection);//ȸ�� 
        HandleAttackDelay();
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);//�̵�ó��.
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
        if (knockbackDurantion > 0.0f)//knockbackDurantion�� �����ִٸ�. 
        {
            direction *= 0.2f;//knockback�� �����ִٸ� �̵��ӵ��� �ٿ��ְ�
            direction += knockback; //knockback�� ���� �����ش�. 
        }
        _rigidbody.velocity = direction;//�̵��ӵ� ����. 
        animationHandler.Move(direction);//�ִϸ��̼� �ڵ鷯�� �̵��ӵ� ����.
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;//�������� ȸ���ϴ��� Ȯ��.

        if (weaponPivot != null)
        {
            weaponPivot.localRotation = Quaternion.Euler(0, 0, rotZ);
        }

        weaponHandler?.Rotate(isLeft);//���� ȸ��.
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
