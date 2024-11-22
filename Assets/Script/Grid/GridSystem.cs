using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private GameObject ground;
    [SerializeField] private int columnLength, rowLength;
    [SerializeField] private float x_Space, z_Space;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < columnLength * rowLength; i++)
        {
            Instantiate(ground, new Vector3(x_Space + (x_Space * (i %columnLength)), 0, z_Space + (z_Space * (i / columnLength))), Quaternion.identity);
        }
    }
}
