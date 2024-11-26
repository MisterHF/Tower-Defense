using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] int health;

    public static Stage Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
    }
}
