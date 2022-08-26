using UnityEngine;

namespace OPSystems.Events
{

    /// <summary>
    /// This class is used for events that have one int argument.
    /// Example: a gateway event, where the bool is representing is door open
    /// </summary>

    [CreateAssetMenu(menuName = "OPSystems/Events/Bool Event Channel")]
    public class BoolEventChannelSO : EventChannelBase<bool>
    { }

}