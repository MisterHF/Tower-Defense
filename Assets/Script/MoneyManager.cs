using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    private void Awake()
    {
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
