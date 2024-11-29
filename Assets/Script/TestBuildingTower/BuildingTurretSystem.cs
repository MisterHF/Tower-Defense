using UnityEngine;

public class BuildingTurretSystem : MonoBehaviour
{
    public TurretData turretLoaded { get; set; }

    [SerializeField] private GameObject prefabTurret;
    [SerializeField] private GameObject gameObjectMask;


    private RectTransform selfTransform;
    private Vector3 newWorldObjectPosition;
    private TowerBehaviour towerBehaviour;
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
    public void Build()
    {
        GameObject newTurret = Instantiate(prefabTurret);
        //MoneyManager.Instance.RemoveMoney(10);
        newTurret.transform.position = transform.position;
        gameObject.SetActive(false);
    }
}
