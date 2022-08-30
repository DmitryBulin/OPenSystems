using UnityEngine;
using OPSystems.SaveSystem;

namespace OPSystems.RuntimeSet
{

    [RequireComponent(typeof(ISaveable))]
    public class SaveableBroadcaster : SetBroadcaster<ISaveable>
    { }

}