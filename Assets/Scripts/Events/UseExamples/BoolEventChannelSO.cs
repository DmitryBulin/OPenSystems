using OPSystems.Events;
using UnityEngine;

/// <summary>
/// This class is used for events that have one int argument.
/// Example: a gateway event, where the bool is representing is door open
/// </summary>

[CreateAssetMenu(menuName = "Event/Bool Event Channel")]
public class BoolEventChannelSO : EventChannelBase<bool>
{ }
