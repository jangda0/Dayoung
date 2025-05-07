using UnityEngine;

public class RangeWeaponHandler : WeaponHandler
{
    [Header("Ranged Attack Data")]
    [SerializeField] private Transform projectileSpawnPosition;

    [SerializeField] private int bulletIndex;//어떤 총알을 사용할지 선택할 수 있게. 
    public int BulletIndex { get { return bulletIndex; } }

    [SerializeField] private float bulletSize = 1f;
    public float BulletSize { get { return bulletSize; } }

    [SerializeField] private float duration = 1f;//총알이 날라가는 동안 얼마나 생존시켜 줄지. 
    public float Duration { get { return duration; } }

    [SerializeField] private float spread = 1f;//총알 퍼짐의 정도. 
    public float Spread { get { return spread; } }

    [SerializeField] private int numberofProjectilesPerShot;//총알 몇발을 쏘개할지. 
    public int NumberofProjectilesPerShot { get { return numberofProjectilesPerShot; } }

    [SerializeField] private float multipleProjectileAngle = 1f;//각각의 탄의 퍼짐 정도
    public float MultipleProjectileAngle { get { return multipleProjectileAngle; } }

    [SerializeField] private Color projectileColor;//각 탄환의 색상. 
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

        //최소 각도 구하기, 최소치 앵들를 구한 후 턴을 쌓아올릴 예정으로 음수로 계산함. 
        float minAngle = -(numberofProjectilesPerShot / 2f) * projectileAngleSpace + 0.5f * multipleProjectileAngle;

        //발사하는 개수만큼 반복 돌기. 
        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            //총알을 발사한 만큼 각도를 계산해서 쏘기. 
            float angle = minAngle + projectileAngleSpace * i;
            //탄퍼짐 랜덤으로 계산. 
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
        //Quaternion의 회전 수치만큼 Vector를 회전시켜줌.
        //하지만 교환법칙을 성립하지 않기 때문에 Vector * Quaternion는 성립되지 않는 계산식. 
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
