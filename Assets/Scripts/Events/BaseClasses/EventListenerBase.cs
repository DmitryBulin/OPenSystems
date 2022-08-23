using UnityEngine;
using UnityEngine.Events;

namespace OPSystems.Events
{

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

}