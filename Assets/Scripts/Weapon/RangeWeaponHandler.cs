using UnityEngine;

public class RangeWeaponHandler : WeaponHandler
{
    [Header("Ranged Attack Data")]
    [SerializeField] private Transform projectileSpawnPosition;

    [SerializeField] private int bulletIndex;//� �Ѿ��� ������� ������ �� �ְ�. 
    public int BulletIndex { get { return bulletIndex; } }

    [SerializeField] private float bulletSize = 1f;
    public float BulletSize { get { return bulletSize; } }

    [SerializeField] private float duration = 1f;//�Ѿ��� ���󰡴� ���� �󸶳� �������� ����. 
    public float Duration { get { return duration; } }

    [SerializeField] private float spread = 1f;//�Ѿ� ������ ����. 
    public float Spread { get { return spread; } }

    [SerializeField] private int numberofProjectilesPerShot;//�Ѿ� ����� �����. 
    public int NumberofProjectilesPerShot { get { return numberofProjectilesPerShot; } }

    [SerializeField] private float multipleProjectileAngle = 1f;//������ ź�� ���� ����
    public float MultipleProjectileAngle { get { return multipleProjectileAngle; } }

    [SerializeField] private Color projectileColor;//�� źȯ�� ����. 
    public Color ProjectileColor { get { return projectileColor; } }

    private ProjectileManager projectileManager;
    protected override void Start()
    {
        base.Start();
        projectileManager = ProjectileManager.Instance;
    }

    public override void Attack()
    {
        base.Attack();

        float projectileAngleSpace = multipleProjectileAngle;
        int numberOfProjectilesPerShot = numberofProjectilesPerShot;

        //�ּ� ���� ���ϱ�, �ּ�ġ �޵鸦 ���� �� ���� �׾ƿø� �������� ������ �����. 
        float minAngle = -(numberofProjectilesPerShot / 2f) * projectileAngleSpace + 0.5f * multipleProjectileAngle;

        //�߻��ϴ� ������ŭ �ݺ� ����. 
        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            //�Ѿ��� �߻��� ��ŭ ������ ����ؼ� ���. 
            float angle = minAngle + projectileAngleSpace * i;
            //ź���� �������� ���. 
            float randomSpread = Random.Range(-spread, spread);
            angle += randomSpread;
            CreateProjectile(Controller.LookDirection, angle);
        }
    }

    private void CreateProjectile(Vector2 _lookDirection, float angle)
    {
        projectileManager.ShootBullet(
        this,
        projectileSpawnPosition.position,
        RotateVector2(_lookDirection, angle));
    }

    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        //Quaternion�� ȸ�� ��ġ��ŭ Vector�� ȸ��������.
        //������ ��ȯ��Ģ�� �������� �ʱ� ������ Vector * Quaternion�� �������� �ʴ� ����. 
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
