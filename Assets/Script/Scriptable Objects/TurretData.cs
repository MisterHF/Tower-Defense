using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurretData", menuName = "Scriptable Objects/TurretData")]
public class TurretData : ScriptableObject
{
    //public string description;
    public int priceTurret;
    public Sprite shopSpriteTurret;

    public float attackSpeed;
    public float range;
    public int attackDamage;
    public float rotationSpeed;



    public List<TurretData> levelTurret = new();


}
