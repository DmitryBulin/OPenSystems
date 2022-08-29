using UnityEngine;

namespace OPSystems.RuntimeSet
{

    /// <summary>
    /// This is an implementation for listing IPausable objects 
    /// </summary>

    [RequireComponent(typeof(IPausable))]
    public class PausableBroadcaster : SetBroadcaster<IPausable>
    { }

}