using UnityEngine;
using UnityEngine.Events;

namespace OPSystems.Events
{

    /// <summary>
    /// Event channel for events without arguments.
    /// Example: Exit game event
    /// </summary>
    [CreateAssetMenu(menuName = "Event/Void Event Channel")]
    public class VoidEventChannelSO : ScriptableObject
    {
        public UnityAction OnEventRaised;

        public void RaiseEvent()
        {
            OnEventRaised?.Invoke();
        }

    }

}
