using UnityEngine;
using UnityEngine.Events;

namespace OPSystems.Events
{

    /// <summary>
    /// A handler for void events in form of a component. Connections can be managed in the Inspector.
    /// </summary>

    public class VoidEventListener : MonoBehaviour
    {

        [SerializeField] private VoidEventChannelSO _channel;
        [SerializeField] private UnityEvent _onEventRaised;

        private void OnEnable()
        {
            if (_channel != null)
            {
                _channel.OnEventRaised += Respond;
            }
        }

        private void OnDisable()
        {
            if (_channel != null)
            {
                _channel.OnEventRaised -= Respond;
            }
        }

        public void Respond()
        {
            _onEventRaised?.Invoke();
        }

    }

}