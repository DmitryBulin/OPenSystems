using UnityEngine;

namespace OPSystems.Factory
{

    /// <summary>
    /// Implements IFactory interface in a form of ScriptableObject entity
    /// </summary>
    /// <typeparam name="T">
    /// Specifies a type for factory to create
    /// </typeparam>

    public abstract class FactorySO<T> : ScriptableObject, IFactory<T>
    {
        public abstract T Create();
    }

}

