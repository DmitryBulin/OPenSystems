using UnityEngine;
using OPSystems.Events;

namespace OPSystems
{

    /// <summary>
    /// Additional implementation for VariableSO to use event channel on changing the value
    /// </summary>
    /// <typeparam name="T">
    /// Type to store
    /// </typeparam>

    public abstract class EventVariableSO<T> : VariableSO<T>
    {
        [SerializeField] private EventChannelBase<T> OnValueChanged;

        public override void ChangeValue(T newValue)
        {
            base.ChangeValue(newValue);
            OnValueChanged?.Raise(Value);
        }

    }

}