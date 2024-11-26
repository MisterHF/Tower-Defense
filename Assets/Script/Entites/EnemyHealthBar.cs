using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider fillAmountImage;

    public Slider FillAmountImage => fillAmountImage;

    public void SetMaxHealth(float health)
    {
        fillAmountImage.maxValue = health;
        fillAmountImage.value = health;
    }
    public void SetHealth(float health)
    {
        fillAmountImage.value = health;
    }
}
