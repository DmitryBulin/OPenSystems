using UnityEngine;
using OPSystems.Events;
using OPSystems.SceneManagement;

/// <summary>
/// Simple handler for batch scene requests
/// Example: Door that separates different levels will raise this batch request
/// </summary>

[CreateAssetMenu(menuName = "Scene Data/Batch Request")] 
public class SceneBatchRequest : ScriptableObject
{
    [SerializeField] private EventChannelBase _raiseEventChannel = default;
    [SerializeField] private bool _showLoadingScreen;
    [SerializeField] private EventChannelBase<GameSceneSO, bool> _loadingEventChannel = default;
    [SerializeField] private EventChannelBase<GameSceneSO> _unloadingEventChannel = default;
    [SerializeField] private GameSceneSO[] _scenesToLoad;
    [SerializeField] private GameSceneSO[] _scenesToUnload;

    private void OnEnable()
    {
        if (_raiseEventChannel != null)
        {
            _raiseEventChannel.OnEventRaised += Raise;
        }
    }

    private void OnDisable()
    {
        if (_raiseEventChannel != null)
        {
            _raiseEventChannel.OnEventRaised -= Raise;
        }
    }

    public void Raise()
    {
        foreach (GameSceneSO gameScene in _scenesToUnload)
        {
            _unloadingEventChannel.Raise(gameScene);
        }
        foreach (GameSceneSO gameScene in _scenesToLoad)
        {
            _loadingEventChannel.Raise(gameScene, _showLoadingScreen);
        }
    }

}
