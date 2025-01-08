using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurretData", menuName = "Scriptable Objects/TurretData")]
public class TurretData : ScriptableObject
{
    //public string description;
    public Sprite shopSpriteTurret;

    public float fireRate;
    public float fireCountdown;
    public float range;
    public float attackDamage;
    public float rotationSpeed;
    public float debuffEffectAmount;
    public int purchaseValue;
    public int sellingValue;

    public GameObject prefabTurret;



    public List<TurretData> levelTurret = new();


}
