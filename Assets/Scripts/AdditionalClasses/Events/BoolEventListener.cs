using UnityEngine;

namespace OPSystems.Events
{

    /// <summary>
    /// Bool event handler in form of a component. Has option to invert incoming bool
    /// Example: If player is dodging, his 'CanAttack' bool should be inverted from 'IsDodging'
    /// </summary>
    
    [AddComponentMenu("OPSystems/Events/Bool Event Listener")]
    public class BoolEventListener : EventListenerBase<bool>
    {
        [SerializeField] private bool _isInverted;

        public override void Respond(bool variable)
        {
            base.Respond(_isInverted ? !variable : variable);
        }

    }

}