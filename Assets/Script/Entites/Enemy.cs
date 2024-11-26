using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    [SerializeField] private int health;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Stage.Instance.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
       //Debug.Log(health + "enemy Health");

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
