namespace OPSystems.Factory
{

    /// <summary>
    /// Represents a factory.
    /// </summary>
    /// <typeparam name="T">
    /// Specifies a type for factory to create
    /// </typeparam>

    public interface IFactory<T>
    {
        T Create();
    }

}
