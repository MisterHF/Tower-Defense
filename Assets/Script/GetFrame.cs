using UnityEngine;

public class GetFrame : MonoBehaviour
{
    public static GetFrame instance;

    [SerializeField] private GameObject frame;

    public GameObject Frame => frame;
    private void Awake()
    {
        instance = this;
    }

}
