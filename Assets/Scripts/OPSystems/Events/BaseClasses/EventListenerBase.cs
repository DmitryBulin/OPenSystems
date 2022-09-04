using UnityEngine;
using UnityEngine.Events;

namespace OPSystems.Events
{

    /// <summary>
    /// Base class for handlers for events with no arguments in form of a component. Connections can be managed in the Inspector.
    /// </summary>

    public abstract class EventListenerBase : MonoBehaviour
    {

        [SerializeField] private EventChannelBase _channel;
        [SerializeField] private UnityEvent _onEventRaised;

        protected virtual void OnEnable()
        {
            if (_channel != null)
            {
                _channel.OnEventRaised += Respond;
            }
        }

        protected virtual void OnDisable()
        {
            if (_channel != null)
            {
                _channel.OnEventRaised -= Respond;
            }
        }

        public virtual void Respond()
        {
            _onEventRaised?.Invoke();
        }

    }

    /// <summary>
    /// Base class for handlers for events with one argument in form of a component. Connections can be managed in the Inspector.
    /// </summary>

    public abstract class EventListenerBase<T> : MonoBehaviour
    {

        [SerializeField] private EventChannelBase<T> _channel;
        [SerializeField] private UnityEvent<T> _onEventRaised;

        protected virtual void OnEnable()
        {
            if (_channel != null)
            {
                _channel.OnEventRaised += Respond;
            }
        }

        protected virtual void OnDisable()
        {
            if (_channel != null)
            {
                _channel.OnEventRaised -= Respond;
            }
        }

        public virtual void Respond(T variable)
        {
            _onEventRaised?.Invoke(variable);
        }

    }

    /// <summary>
    /// Base class for handlers for events with two argument in form of a component. Connections can be managed in the Inspector.
    /// </summary>

    public abstract class EventListenerBase<T0, T1> : MonoBehaviour
    {

        [SerializeField] private EventChannelBase<T0, T1> _channel;
        [SerializeField] private UnityEvent<T0, T1> _onEventRaised;

        protected virtual void OnEnable()
        {
            if (_channel != null)
            {
                _channel.OnEventRaised += Respond;
            }
        }

        protected virtual void OnDisable()
        {
            if (_channel != null)
            {
                _channel.OnEventRaised -= Respond;
            }
        }

        public virtual void Respond(T0 variable0, T1 variable1)
        {
            _onEventRaised?.Invoke(variable0, variable1);
        }

    }

    /// <summary>
    /// Base class for handlers for events with three argument in form of a component. Connections can be managed in the Inspector.
    /// </summary>

    public abstract class EventListenerBase<T0, T1, T2> : MonoBehaviour
    {

        [SerializeField] private EventChannelBase<T0, T1, T2> _channel;
        [SerializeField] private UnityEvent<T0, T1, T2> _onEventRaised;

        protected virtual void OnEnable()
        {
            if (_channel != null)
            {
                _channel.OnEventRaised += Respond;
            }
        }

        protected virtual void OnDisable()
        {
            if (_channel != null)
            {
                _channel.OnEventRaised -= Respond;
            }
        }

        public virtual void Respond(T0 variable0, T1 variable1, T2 variable2)
        {
            _onEventRaised?.Invoke(variable0, variable1, variable2);
        }

    }
}