using UnityEngine;

namespace OPSystems.SceneManagement
{

    /// <summary>
    /// This class contains settings specific for UI scenes
    /// Example: Main Menu, Settings Menu
    /// </summary>

    [CreateAssetMenu(menuName = "OPSystems/Scene Data/Menu")]
    public class MenuSO : GameSceneSO
    {
        [Header("Menu settings")]
        public Menu MenuType;
    }

    public enum Menu
    {
        Main_Menu,
        Sub_Menu
    }

}