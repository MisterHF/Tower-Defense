using UnityEngine;
using UnityEngine.UI;

public class ManageBuiltUpTurrets : MonoBehaviour
{
    [SerializeField] GameObject buttonUpgrade;

    private TowerBehaviour tower;

    [HideInInspector]
    public GameObject baseTurret;
    public TurretData data { get; set; }

    private void Awake()
    {
        tower = GetComponentInChildren<TowerBehaviour>();
    }
    public void Sell(TurretData data)
    {
        MoneyManager.Instance.AddMoney(data.sellingValue);

        Destroy(gameObject);
        
        baseTurret.SetActive(true);
    }

    public void UpgradeTurret(TurretData data)
    {
        MoneyManager.Instance.RemoveMoney(tower.stat.lvlUpTurretValue);
        if (Stage.Instance.currentMoney >= tower.stat.lvlUpTurretValue)
        {
            tower.stat.lvlTurret++;
            tower.stat.lvlUpTurretValue += data.lvlUpTurretValue;

            tower.stat.attackDamage += data.attackDamage;
            tower.stat.range += 0.25f;
        }

        if (tower.stat.lvlTurret >= 3)
        {
            buttonUpgrade.GetComponent<Button>().enabled = false;
            buttonUpgrade.GetComponent<Image>().color = Color.red;
        }
    }

}

    // fonction pour upgrade tower avec 3 niveaux d amelio

    // fonction pour downgrade une tour amelio

    // fonction pour vendre