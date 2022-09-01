using UnityEngine;

namespace OPSystems
{

    /// <summary>
    /// Base class for managing variables of the certain type
    /// </summary>
    /// <typeparam name="T">
    /// Type of the stored data
    /// </typeparam>

    public abstract class VariableSO<T> : ScriptableObject
    {
        [SerializeField] private T _value;

        public T Value
        {
            get => _value;
            set => ChangeValue(value);
        }

        public virtual void ChangeValue(T newValue)
        {
            _value = newValue;
        }

    }

}