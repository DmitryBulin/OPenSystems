using UnityEngine;
using UnityEngine.Events;

namespace OPSystems.Events
{

    /// <summary>
    /// Base class for event channels that pass one parameter through channel.
    /// </summary>
    /// <typeparam name="T">
    /// Type of variable to pass
    /// </typeparam>

    public abstract class EventChannelBase<T> : ScriptableObject
    {
        public UnityAction<T> OnEventRaised;

        public virtual void Raise(T variable)
        {
            OnEventRaised?.Invoke(variable);
        }

    }

}