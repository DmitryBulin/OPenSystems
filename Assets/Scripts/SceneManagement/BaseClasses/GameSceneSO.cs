using UnityEngine;

namespace OPSystems.SceneManagement
{

    /// <summary>
    /// This is a base class for all game scenes
    /// Example: Location, Menu
    /// </summary>

    public abstract partial class GameSceneSO : ScriptableObject
    {
        [Header("Info")]
#if UNITY_EDITOR // See GameSceneSOEditor.cs
        public UnityEditor.SceneAsset SceneAsset;
        [TextArea] [SerializeField] private string _shortDescription;
#endif
        [HideInInspector] public string ScenePath;
    }

}