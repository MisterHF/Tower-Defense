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
    public int attackDamage;
    public float rotationSpeed;
    public float slowAmount;



    public List<TurretData> levelTurret = new();


}
