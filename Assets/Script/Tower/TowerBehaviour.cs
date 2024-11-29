using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public TurretData data;

    [SerializeField] protected Transform turretRotation;

    protected Collider2D hitColliders;
    protected Enemy enemy;
    protected Plot plot;

    // Update is called once per frame
    protected virtual void Update()
    {
        if (enemy == null)
        {
            TowerDetectEnemy();
            return;
        }
        else if (enemy != null)
        {
            Shoot();
        }
    }

    protected virtual void Shoot()
    {
        if (CheckEnemyIsInRange())
        {
            RotateTowardsEnemy();
            if (data.fireCountdown <= 0f)
            {
                DealDamage();

                data.fireCountdown = 1 / data.fireRate;
                return;
            }
        }
        else
        {
            enemy = null;
        }
        data.fireCountdown -= Time.deltaTime;
    }
    protected void TowerDetectEnemy()
    {
        hitColliders = Physics2D.OverlapCircle(transform.position, data.range);
        if (hitColliders == null) return;
        enemy = hitColliders.gameObject.GetComponent<Enemy>();
    }

    protected bool CheckEnemyIsInRange()
    {
        return Vector3.Distance(enemy.transform.position, transform.position) <= data.range;
    }


    protected void RotateTowardsEnemy()
    {
        float angle = Mathf.Atan2(enemy.transform.position.y - transform.position.y, enemy.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion enemyRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotation.rotation = Quaternion.RotateTowards(turretRotation.rotation, enemyRotation, data.rotationSpeed * Time.deltaTime);
    }

    protected void DealDamage()
    {
        enemy.TakeDamage(data.attackDamage);
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3);
    }

    public void UpgradeTurret(TurretData turretData)
    {
        data = turretData;
        GetComponent<SpriteRenderer>().sprite = data.shopSpriteTurret;
        MoneyManager.Instance.RemoveMoney(10);
    }
    public void SellTurret()
    {
        //plot.sr.enabled = true;
        Destroy(gameObject);
        MoneyManager.Instance.AddMoney(10);
        turretRotation.rotation = default;
    }
}
