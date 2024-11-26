using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildTurretSystem : MonoBehaviour
{
    public TurretData turretLoaded { get; set; }
    public static Action<TurretData> OnPlaceTurret;

    [SerializeField] private GameObject gameObjectMask;
    [SerializeField] private List<GameObject> button = new();

    private RectTransform selfTransform;
    private Vector3 newWorldObjectPosition;
    private TowerBehaviour towerBehaviour;


    private void Awake()
    {
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
    public void PlaceTurret()
    {
        OnPlaceTurret?.Invoke(turretLoaded);
    }

    public void UpgradeTurret(int index)
    {
        towerBehaviour.UpgradeTurret(towerBehaviour.data.levelTurret[index]);
    }
}
