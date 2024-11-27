using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    [SerializeField] private Transform barHealthPos;
    [SerializeField] private GameObject healthBarPrefab;

    public EnemyHealthBar healthBar;

    UnityEvent ShowEnemyHealthBar = new();

    private void Start()
    {
        ShowEnemyHealthBar.AddListener(ShowHealthBar);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBarPrefab.SetActive(false);
    }

    private void ShowHealthBar()
    {
        if (currentHealth == maxHealth)
        {
            healthBarPrefab.SetActive(false);
        }
        else
        {
            healthBarPrefab.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Stage.Instance.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        ShowEnemyHealthBar.Invoke();
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);


        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
