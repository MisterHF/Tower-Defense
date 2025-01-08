using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform barHealthPos;
    [SerializeField] private GameObject healthBarPrefab;

    public EnemyHealthBar healthBar;
    public enemieStat stat;
    public Spawner spawner;

    UnityEvent ShowEnemyHealthBar = new();

    private Coroutine resetMalus;
    private MoneyManager moneyManager;

    [System.Serializable]
    public struct enemieStat
    {
        public float currentHealth, maxHealth, currentSpeed, maxSpeed;
        public int gold, damage;
        public bool isAttacked;
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

    public void SpeedMalus(float percent)
    {
        stat.currentSpeed = Mathf.Max(0.5f, stat.currentSpeed / percent);
    }

    public void TakeDamage(float damage)
    {
        ShowEnemyHealthBar.Invoke();
        stat.currentHealth -= damage;
        healthBar.SetHealth(stat.currentHealth);

        if (stat.currentHealth <= 0)
        {
            MoneyManager.Instance.AddMoney(stat.gold);
            spawner.OnReleaseEnemy(this);
        }
        else
        {
            if (resetMalus != null)
            {
                StopCoroutine(resetMalus);
            }
            resetMalus = StartCoroutine(RemoveMalusAfterDelay(0.5f));
        }
    }

    private IEnumerator RemoveMalusAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetMalus();
    }


    public void ResetMalus()
    {
        stat.currentSpeed = stat.maxSpeed;
    }
}
