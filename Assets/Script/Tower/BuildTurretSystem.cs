using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildTurretSystem : MonoBehaviour
{
    public TurretData turretLoaded { get; set; }

    [SerializeField] private GameObject[] towerPrefabs;

    private int selectorTower = 0;

    [SerializeField] private GameObject gameObjectMask;
    [SerializeField] private List<GameObject> button = new();

    private RectTransform selfTransform;
    private Vector3 newWorldObjectPosition;
    private TowerBehaviour towerBehaviour;

    public static BuildTurretSystem instance;

    private void Awake()
    {
        instance = this;
        selfTransform = GetComponent<RectTransform>();
    }
    public void SetupTurretButton(TowerBehaviour towerBehaviour)
    {

        this.towerBehaviour = towerBehaviour;
        for (int i = 0; i < button.Count; i++)
        {
            button[i].SetActive(false);
        }
        for (int i = 0; i < towerBehaviour.data.levelTurret.Count; i++)
        {
            button[i].SetActive(true);
        }
        gameObjectMask.SetActive(true);
        RectTransformUtility.ScreenPointToWorldPointInRectangle(selfTransform, transform.position, Camera.main, out newWorldObjectPosition);
        gameObjectMask.transform.position = newWorldObjectPosition;
    }

    private void OnDisable()
    {
        gameObjectMask.SetActive(false);
    }
    public GameObject GetSelectedTower()
    {
        MoneyManager.Instance.RemoveMoney(10);
        gameObject.SetActive(false);
        return towerPrefabs[selectorTower];
    }
    public void UpgradeTurret(int index)
    {
        towerBehaviour.UpgradeTurret(towerBehaviour.data.levelTurret[index]);
        gameObject.SetActive(false);
    }
    public void SellTurret()
    {
        towerBehaviour.SellTurret();
        gameObject.SetActive(false);
    }
}
