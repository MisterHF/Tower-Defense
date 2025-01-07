using UnityEngine;

public class BuildingTurretSystem : MonoBehaviour
{
    public TurretData turretLoaded { get; set; }

    private TowerBehaviour tower;

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
        //MoneyManager.Instance.RemoveMoney(10);

        tower = newTurret.GetComponent<TowerBehaviour>(); ;
        newTurret.transform.position = transform.position;
        gameObject.SetActive(false);
        tower.InitializedDataTurret(data);
    }
}
