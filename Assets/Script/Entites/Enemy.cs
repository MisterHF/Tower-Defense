using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public enemieStat stat;

    [SerializeField] private Transform barHealthPos;
    [SerializeField] private GameObject healthBarPrefab;

    public EnemyHealthBar healthBar;

    UnityEvent ShowEnemyHealthBar = new();

    public Spawner spawner;

    [System.Serializable]
    public struct enemieStat
    {
        public float currentHealth, maxHealth, speed;
        public int gold, damage;
    }


    private void Start()
    {
        ShowEnemyHealthBar.AddListener(ShowHealthBar);
        stat.currentHealth = stat.maxHealth;
        healthBar.SetMaxHealth(stat.maxHealth);
        healthBarPrefab.SetActive(false);
    }

    private void ShowHealthBar()
    {
        if (stat.currentHealth == stat.maxHealth)
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
            Stage.Instance.TakeDamage(stat.damage);
        }
    }

    public void TakeMalusOnStat( enemieStat stat, float percent)
    {
        stat.speed /= percent;
    }

    public void TakeDamage(float damage)
    {
        ShowEnemyHealthBar.Invoke();
        stat.currentHealth -= damage;
        healthBar.SetHealth(stat.currentHealth);


        if (stat.currentHealth <= 0)
        {
            spawner.OnReleaseEnemy(this);
        }
    }
}
