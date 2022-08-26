using UnityEngine;

namespace OPSystems.Events
{

    /// <summary>
    /// This class is used for events that have one int argument.
    /// Example: An unlock event, where the int is the ID of unlocked item/achievment/etc.
    /// </summary>

    [CreateAssetMenu(menuName = "OPSystems/Events/Int Event Channel")]
    public class IntEventChannelSO : EventChannelBase<int>
    { }

}