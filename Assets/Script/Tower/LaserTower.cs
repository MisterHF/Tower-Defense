using UnityEngine;

public class LaserTower : TowerBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    //[SerializeField] ParticleSystem impactEffect;
    [SerializeField] Transform firePoint;

    protected override void Update()
    {
        if (enemy == null)
        {
            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
            TowerDetectEnemy();
            return;
        }
        else if (enemy != null)
        {
            Laser();
            Shoot();
        }
    }
    protected override void Shoot()
    {
        //a changer pour le comportement du laser
        // voir comment et ou appliquer les degats

        if (CheckEnemyIsInRange())
        {
            RotateTowardsEnemy();
            DealDamage();
        }
        else
        {
            enemy = null;
        }
    }

    private void Laser()
    {
        if (!lineRenderer.enabled) lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, enemy.GetComponent<Transform>().position);
    }
}
