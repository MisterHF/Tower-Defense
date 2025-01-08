using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void AddMoney(int amount)
    {
        Stage.Instance.AddMoney(amount);
    }

    public void RemoveMoney(int amount)
    {
        Stage.Instance.AddMoney(-amount);
    }
}
