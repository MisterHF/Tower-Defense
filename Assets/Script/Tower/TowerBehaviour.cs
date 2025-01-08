using UnityEngine;

public abstract class TowerBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask enemylayer;
    [SerializeField] private Transform turretRotation;
    [SerializeField] private float fovRangeTurret;

    private Collider2D hitColliders;

    protected Enemy enemy;

    public TurretData data;
    public statTurret stat;

    [System.Serializable]
    public struct statTurret
    {
        public float fireRate, range, fireCountdown, attackDamage, rotationSpeed, debuffEffectAmount;
        public int purchaseValue, sellingValue;
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        ResetLineRenderer();

        if (enemy == null)
        {
            TowerDetectEnemy();
            return;
        }
        else if (enemy != null)
        {

            if (CheckEnemyIsInRange())
            {
                RotateTowardsEnemy();

                if (CheckEnemyInFOV())
                {
                    AttackRenderer();
                    stat.fireCountdown -= Time.deltaTime;
                    if (stat.fireCountdown <= 0f)
                    {
                        Shoot();
                        stat.fireCountdown = stat.fireRate;
                    }
                }
            }
            else
            {
                enemy = null;
                stat.fireCountdown = stat.fireRate;
            }
        }
    }
    protected virtual void AttackRenderer() { }
    protected virtual void ResetLineRenderer() { }
    protected abstract void Shoot();

    private void TowerDetectEnemy()
    {
        stat.fireCountdown = stat.fireRate;
        hitColliders = Physics2D.OverlapCircle(transform.position, stat.range, enemylayer);
        if (hitColliders == null) return;
        enemy = hitColliders.gameObject.GetComponent<Enemy>();
    }

    private bool CheckEnemyIsInRange()
    {
        return Vector3.Distance(enemy.transform.position, transform.position) <= stat.range;
    }

    private bool CheckEnemyInFOV()
    {
        Vector2 dir = enemy.transform.position - transform.position;
        float dot = Vector2.Dot(transform.up, dir);
        return dot > fovRangeTurret;
    }


    private void RotateTowardsEnemy()
    {
        float angle = Mathf.Atan2(enemy.transform.position.y - transform.position.y, enemy.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion enemyRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotation.rotation = Quaternion.RotateTowards(turretRotation.rotation, enemyRotation, stat.rotationSpeed * Time.deltaTime);
    }

    protected virtual void DealDamage()
    {
        enemy.TakeDamage(stat.attackDamage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3);
    }

    public void InitializedDataTurret(TurretData data)
    {
        stat.range = data.range;
        stat.attackDamage = data.attackDamage;
        stat.fireRate = data.fireRate;
        stat.fireCountdown = data.fireCountdown;
        stat.rotationSpeed = data.rotationSpeed;
        stat.debuffEffectAmount = data.debuffEffectAmount;
        stat.purchaseValue = data.purchaseValue;
        stat.sellingValue = data.sellingValue;
    }

    //public void UpgradeTurret(TurretData turretData)
    //{
    //    data = turretData;
    //    GetComponent<SpriteRenderer>().sprite = data.shopSpriteTurret;
    //    MoneyManager.Instance.RemoveMoney(10);


    //}
    //public void SellTurret()
    //{
    //    MoneyManager.Instance.AddMoney(stat.sellingValue);
    //    turretRotation.rotation = default;
    //}
}
