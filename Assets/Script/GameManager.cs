using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UnityEvent ONGameFinish = new();

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ONGameFinish.AddListener(IsAlive);
    }

    private void IsAlive()
    {
        if (Stage.Instance.health <= 0)
        {
            print("load end scene");
        }
    }
}
