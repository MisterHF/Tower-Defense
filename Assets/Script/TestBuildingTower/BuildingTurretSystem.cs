using System;
using UnityEngine;

public class BuildingTurretSystem : MonoBehaviour
{
    public TurretData turretLoaded { get; set; }

    private TowerBehaviour tower;
    private ManageBuiltUpTurrets manager;

    [SerializeField] private GameObject prefabTurret;
    [SerializeField] private GameObject gameObjectMask;

    private RectTransform selfTransform;
    private Vector3 newWorldObjectPosition;


    public void SetupWheelTurretUI()
    {
        gameObjectMask.SetActive(true);
        RectTransformUtility.ScreenPointToWorldPointInRectangle(selfTransform, transform.position, Camera.main, out newWorldObjectPosition);
        gameObjectMask.transform.position = newWorldObjectPosition;
    }
    //private void OnDisable()
    //{
    //    gameObjectMask.SetActive(false);
    //}
    public void Build(TurretData data)
    {

        GameObject newTurret = Instantiate(data.prefabTurret);
        MoneyManager.Instance.RemoveMoney(data.purchaseValue);

        tower = newTurret.GetComponentInChildren<TowerBehaviour>();
        newTurret.transform.position = transform.position;
        gameObject.SetActive(false);
        tower.InitializedDataTurret(data);

        manager = newTurret.GetComponent<ManageBuiltUpTurrets>();
        manager.baseTurret = this.gameObject;
    }
}
