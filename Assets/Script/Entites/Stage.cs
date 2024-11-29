using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Stage : MonoBehaviour
{
    [SerializeField] public int health { get; private set; } = 20;
    private int currentHealth;

    public int startmoney = 200;
    public int currentMoney;

    [SerializeField] TextMeshProUGUI textCurrentMoney;
    [SerializeField] TextMeshProUGUI textCurrentHealth;

    UnityEvent UpdateTextHealth = new();
    UnityEvent UpdateTextMoney = new();

    public static Stage Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateTextHealth.AddListener(UpdateCurrentHealthText);
        UpdateTextMoney.AddListener(UpdateCurrentMoneyText);
        currentHealth = health;
        currentMoney = startmoney;
        UpdateCurrentHealthText();
        UpdateCurrentMoneyText();
    }

    public void AddMoney(int amount) 
    {
        currentMoney += amount;
        UpdateTextMoney.Invoke();
    }
    private void UpdateCurrentHealthText()
    {
        textCurrentHealth.text = health + " ";
    }
    private void UpdateCurrentMoneyText()
    {
        textCurrentMoney.text = currentMoney + " ";
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        UpdateTextHealth.Invoke();
        GameManager.Instance.ONGameFinish.Invoke();

    }
}
