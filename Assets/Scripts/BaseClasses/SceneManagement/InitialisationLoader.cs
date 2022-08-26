using UnityEngine;
using UnityEngine.SceneManagement;

namespace OPSystems.SceneManagement
{

    /// <summary>
    /// This class is responsible for loading all the necessary scenes at the start of the game
    /// Example: Loading PersistentManagers, then MainMenuLocation, then MainMenuUI
    /// </summary>

    public class InitialisationLoader : MonoBehaviour
    {
        [Tooltip("This scenes would be loaded in a precise order they are arranged in this array")]
        [SerializeField] private GameSceneSO[] _scenesToLoad;

        private int _sceneToLoadIndex;

        void Start()
        {
            _sceneToLoadIndex = 0;
            LoadNextScene();
        }

        public void LoadNextScene()
        {
            if (_sceneToLoadIndex == _scenesToLoad.Length)
            {
                SceneManager.UnloadSceneAsync(0); // Initialisation should be the only scene in BuildSettings, thus it would have index 0
            }
            else
            {
                SceneManager.LoadSceneAsync(_scenesToLoad[_sceneToLoadIndex].ScenePath, LoadSceneMode.Additive).completed += delegate { LoadNextScene(); };
                ++_sceneToLoadIndex;
            }
        }        
    }

}