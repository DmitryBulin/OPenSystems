#if UNITY_EDITOR

using System;
using UnityEngine;

namespace OPSystems.SceneManagement
{
    /// <summary>
    /// This is second part of GameSceneSO class implementation
    /// It is responsible for managing editor-related functionality
    /// </summary>

    public abstract partial class GameSceneSO : ScriptableObject, ISerializationCallbackReceiver
    {
        public static Action<GameSceneSO> OnEnabled;
        private UnityEditor.SceneAsset _previousSceneAsset;

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            PopulateScenePath();
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        { }

        private void OnEnable()
        {
            // In case domain was nor reloaded after entering play mode
            _previousSceneAsset = null;
            PopulateScenePath();
            OnEnabled?.Invoke(this);
        }

        private void PopulateScenePath()
        {
            if (SceneAsset != null)
            {
                if (_previousSceneAsset != SceneAsset)
                {
                    // To prevent constant invocation of AssetDatabase API
                    // when this SO is opened in the Inspector.
                    _previousSceneAsset = SceneAsset;
                    ScenePath = UnityEditor.AssetDatabase.GetAssetPath(SceneAsset);
                }
            }
            else
            {
                ScenePath = null;
            }
        }

    }

}
#endif