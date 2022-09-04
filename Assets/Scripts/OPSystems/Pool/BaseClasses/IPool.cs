namespace OPSystems.Pool
{

    /// <summary>
    /// Represents a pool that stores objects
    /// </summary>
    /// <typeparam name="T">
    /// Specifies a type for pool to store
    /// </typeparam>

    public interface IPool<T>
    {
        void Prewarm(int num);
        T Request();
        void Return(T member);
    }
}
