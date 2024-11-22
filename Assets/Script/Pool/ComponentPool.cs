using UnityEngine;



public class ComponentPool<T> : IPool<T> where T : Component, IPoolObject<T>
{
    private readonly Pool<T> _pool;

    public int PooledObjectsCount => _pool.PooledObjectsCount;

    public int AliveObjectsCount => _pool.AliveObjectsCount;

    public ComponentPool(GameObject prefab, int capacity = 50, int preAllocationCount = 0)
    {
        _pool = new(
            () =>
        {
            GameObject gameObject = Object.Instantiate(prefab);
            T component = gameObject.GetComponent<T>();
            return component;
        },

            (component) =>
            {
                component.gameObject.SetActive(true);
            },


            (component) =>
            { component.gameObject.SetActive(false); },

            capacity, preAllocationCount);
    }

    public T Get()
    {
        return _pool.Get();
    }

    public void Release(T obj)
    {
        _pool.Release(obj);
    }
}

