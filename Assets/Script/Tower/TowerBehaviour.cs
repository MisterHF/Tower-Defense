using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public TurretData data;

    [SerializeField] private Transform turretRotation;

    private Collider2D hitColliders;
    private Enemy enemy;

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            TowerDetectEnemy();
            return;
        }
        else if (enemy != null)
        {
            if (CheckEnemyIsInRange())
            {
                DealDamage();
                RotateTowardsEnemy();
                return;
            }
            else
            {
                enemy = null;
            }
        }
    }

    private void TowerDetectEnemy()
    {
        hitColliders = Physics2D.OverlapCircle(transform.position, data.range);
        if (hitColliders == null) return;
        enemy = hitColliders.gameObject.GetComponent<Enemy>();
    }

    private bool CheckEnemyIsInRange()
    {
        return Vector3.Distance(enemy.transform.position, transform.position) <= data.range;
    }


    private void RotateTowardsEnemy()
    {
        float angle = Mathf.Atan2(enemy.transform.position.y - transform.position.y, enemy.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion enemyRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotation.rotation = Quaternion.RotateTowards(turretRotation.rotation, enemyRotation, data.rotationSpeed * Time.deltaTime);
    }

    private void DealDamage()
    {
        enemy.TakeDamage(data.attackDamage);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3);
    }

    public void UpgradeTurret(TurretData turretData)
    {
        data = turretData;
        GetComponent<SpriteRenderer>().sprite = data.shopSpriteTurret;
    }
    public void SellTurret(TurretData turretData)
    {
        data = turretData;
        GetComponent<SpriteRenderer>().sprite = data.shopSpriteTurret;
        turretRotation.rotation = default;
    }
}
