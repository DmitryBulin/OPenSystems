using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using OPSystems.Events;

namespace OPSystems.SceneManagement
{

    /// <summary>
    /// This class manages loading and unloading scenes
    /// </summary>

    public class SceneLoader : MonoBehaviour
    {
        [Tooltip("This scene will be always active during application lifetime")]
        [SerializeField] private GameSceneSO _persistentScene;
        [Header("Listening to")]
        [Tooltip("Event channel for requesting game exit")]
        [SerializeField] private EventChannelBase _gameExitChannel = default;
        [Tooltip("Event channel to load scenes")]
        [SerializeField] private EventChannelBase<GameSceneSO, bool> _loadSceneChannel = default;
        [Tooltip("Event channel to unload scenes")]
        [SerializeField] private EventChannelBase<GameSceneSO> _unloadSceneChannel = default;

        [Header("Broadcasting on")]
        [SerializeField] private EventChannelBase<bool> _toggleLoadingScreen = default;
        [SerializeField] private EventChannelBase _onSceneReady = default;

        private List<AsyncOperation> _scenesToLoadAsyncOperations = new List<AsyncOperation>();
        private List<AsyncOperation> _scenesToUnloadAsyncOperations = new List<AsyncOperation>();
        private GameSceneSO _activeScene;
        private bool _isLoading;
        private bool _isUnloading;
        
        private void OnEnable()
        {
            _gameExitChannel.OnEventRaised += ExitGame;
            _loadSceneChannel.OnEventRaised += LoadScene;
            _unloadSceneChannel.OnEventRaised += UnloadScene;
        }

        private void OnDisable()
        {
            _gameExitChannel.OnEventRaised -= ExitGame;
            _loadSceneChannel.OnEventRaised -= LoadScene;
            _unloadSceneChannel.OnEventRaised -= UnloadScene;
        }

        /// <summary>
        /// Loads requested scene. 
        /// Starts waiting coroutine if no scenes were loading
        /// </summary>
        /// <param name="sceneToLoad">
        /// Scene to load
        /// </param>
        /// <param name="showLoadingScreen">
        /// Specifies if loading screen should be toggled while loading this scene
        /// </param>
       
        public void LoadScene(GameSceneSO sceneToLoad, bool showLoadingScreen)
        {
            if (_activeScene == null)
            {
                _activeScene = sceneToLoad;
            }
                        
            _scenesToLoadAsyncOperations.Add(SceneManager.LoadSceneAsync(sceneToLoad.ScenePath, LoadSceneMode.Additive));

            if (!_isLoading)
            {
                StartCoroutine(WaitForLoading(showLoadingScreen));
            }
        }

        /// <summary>
        /// Unloads requested scene. 
        /// Starts waiting coroutine if no scenes were unloading
        /// </summary>
        /// <param name="sceneToUnload">
        /// Scene to unload
        /// </param>

        public void UnloadScene(GameSceneSO sceneToUnload)
        {
            if (sceneToUnload.ScenePath == _activeScene.ScenePath)
            {
                _activeScene = null;
            }

            _scenesToUnloadAsyncOperations.Add(SceneManager.UnloadSceneAsync(sceneToUnload.ScenePath));

            if (!_isUnloading)
            {
                StartCoroutine(WaitForUnloading());
            }
        }

        /// <summary>
        /// Sets active scene for SceneManager after all the scenes were loaded
        /// </summary>

        private void SetActiveScene()
        {
            if (_activeScene == null)
            {
                Debug.LogWarning("Didn't have active scene to set. Loading events might have been raised before unloading ones.");
                _activeScene = _persistentScene;
            }

            SceneManager.SetActiveScene(SceneManager.GetSceneByPath(_activeScene.ScenePath));
            // Will reconstruct LightProbe tetrahedrons to include the probes from the newly-loaded scene
            LightProbes.TetrahedralizeAsync();
            // Raise the event to inform that the scene is loaded and set active
            _onSceneReady.Raise();
        }

        /// <summary>
        /// Waiting for all the requested scenes to load
        /// </summary>
        /// <param name="showLoadingScene">
        /// Specifies if event _toggleLoadingScreen needs to be raised
        /// </param>

        private IEnumerator WaitForLoading(bool showLoadingScreen)
        {
            bool loadingIsDone = false;

            if (showLoadingScreen)
            {
                _toggleLoadingScreen.Raise(showLoadingScreen);
            }

            while (!loadingIsDone)
            {
                yield return null;

                for (int i = 0; i < _scenesToLoadAsyncOperations.Count; ++i)
                {

                    if (!_scenesToLoadAsyncOperations[i].isDone)
                    {
                        break;
                    }
                    else
                    {
                        loadingIsDone = true;
                    }
                }

            }

            _isLoading = false;
            _scenesToLoadAsyncOperations.Clear();
            SetActiveScene();

            if (showLoadingScreen)
            {
                _toggleLoadingScreen.Raise(false);
            }

        }

        /// <summary>
        /// Waiting for all the requested scenes to unload
        /// </summary>

        private IEnumerator WaitForUnloading()
        {
            bool unloadingIsDone = false;

            while (!unloadingIsDone)
            {
                yield return null;

                for (int i = 0; i < _scenesToUnloadAsyncOperations.Count; ++i)
                {
                    if (!_scenesToUnloadAsyncOperations[i].isDone)
                    {
                        break;
                    }
                    else
                    {
                        unloadingIsDone = true;
                        _isUnloading = false;
                        _scenesToUnloadAsyncOperations.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// Exits the application upon request
        /// </summary>

        private void ExitGame()
        {
            Application.Quit();
        }

    }
}
