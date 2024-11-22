using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour, IPoolObject<Enemy>
{
    [SerializeField] private int damage = 1;

    private Pool<Enemy> enemyPool;

    
    public void SetPool(Pool<Enemy> pool)
    {
        enemyPool = pool;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Stage stage = GetComponent<Stage>();
            stage.TakeDamage(damage);
            enemyPool.Release(this);
        }
    }
}
