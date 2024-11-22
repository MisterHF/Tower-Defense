public interface IPoolObject<T> where T : class, IPoolObject<T>
{
    void SetPool(Pool<T> pool);
}

