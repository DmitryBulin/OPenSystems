using UnityEngine;
using OPSystems.SceneManagement;

namespace OPSystems.Events
{
    
    /// <summary>
    /// This channel is raised to unload certain scene
    /// </summary>

    [CreateAssetMenu(menuName = "OPSystems/Events/Unload Event Channel")]
    public class UnloadEventChannelSO : EventChannelBase<GameSceneSO>
    { }

}