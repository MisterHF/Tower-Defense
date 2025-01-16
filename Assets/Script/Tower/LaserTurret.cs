using UnityEngine;

public class LaserTurret : TowerBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField] private Transform turretFirePoint;
   

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.transform.position = turretFirePoint.position;
    }

    protected override void Update()
    {
        base.Update();
    }
    protected override void AttackRenderer()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, turretFirePoint.position);
        lineRenderer.SetPosition(1, enemy.transform.position);
    }
    protected override void Shoot()
    {
        enemy.SpeedMalus(data.debuffEffectAmount);
        DealDamage();
        return;
    }
    protected override void ResetLineRenderer()
    {
        lineRenderer.enabled = false;
    }
}
