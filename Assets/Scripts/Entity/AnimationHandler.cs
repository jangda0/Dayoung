using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    //���ڸ� ���ϴ� �ͺ���, ���ڸ� ���ϴ� ���� ���������� Hash��� ���� ���ڷ� ��ȯ����. 
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");

    protected Animator animator;


    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > 0.5f);
    }

    public void Damage()
    {
        animator.SetBool(IsDamage, true);
    }

    public void InvincibilityEnd()
    {
        animator.SetBool(IsDamage, false);
    }
}
