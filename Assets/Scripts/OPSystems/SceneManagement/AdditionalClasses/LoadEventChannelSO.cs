using UnityEngine;
using OPSystems.SceneManagement;

namespace OPSystems.Events
{

    /// <summary>
    /// This channel is raised to load certain scene, with or without showing loading screen
    /// </summary>

    [CreateAssetMenu(menuName = "OPSystems/Events/Load Event Channel")]
    public class LoadEventChannelSO : EventChannelBase<GameSceneSO, bool>
    { }

}
