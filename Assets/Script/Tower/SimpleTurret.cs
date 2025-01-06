using UnityEngine;

public class SimpleTurret : TowerBehaviour
{
    protected override void Shoot()
    {
        DealDamage();

        return;
    }

    protected override void DealDamage()
    {
        base.DealDamage();
    }
}
