using UnityEngine;
using UnityEngine.Events;

namespace OPSystems.Events
{

    /// <summary>
    /// Base class for event channels that pass no parameters through channel.
    /// </summary>

    public abstract class EventChannelBase : ScriptableObject
    {
        public UnityAction OnEventRaised;

        public virtual void Raise()
        {
            OnEventRaised?.Invoke();
        }

    }

    /// <summary>
    /// Base class for event channels that pass one parameter through channel.
    /// </summary>

    public abstract class EventChannelBase<T> : ScriptableObject
    {
        public UnityAction<T> OnEventRaised;

        public virtual void Raise(T variable)
        {
            OnEventRaised?.Invoke(variable);
        }

    }

    /// <summary>
    /// Base class for event channels that pass two parameter through channel.
    /// </summary>

    public abstract class EventChannelBase<T0, T1> : ScriptableObject
    {
        public UnityAction<T0, T1> OnEventRaised;

        public virtual void Raise(T0 variable0, T1 variable1)
        {
            OnEventRaised?.Invoke(variable0, variable1);
        }

    }

    /// <summary>
    /// Base class for event channels that pass three parameter through channel.
    /// </summary>

    public abstract class EventChannelBase<T0, T1, T2> : ScriptableObject
    {
        public UnityAction<T0, T1, T2> OnEventRaised;

        public virtual void Raise(T0 variable0, T1 variable1, T2 variable2)
        {
            OnEventRaised?.Invoke(variable0, variable1, variable2);
        }

    }
}