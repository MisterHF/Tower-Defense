using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] int health;

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
