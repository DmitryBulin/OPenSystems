using UnityEngine;
using OPSystems.SceneManagement;

/// <summary>
/// This class contains settings specific for location scenes
/// Example: Swamp Temple, Forest
/// </summary>

[CreateAssetMenu(menuName = "Scene Data/Location")]
public class LocationSO : GameSceneSO
{
    [Header("Location settings")]
    public string LocationTitle;
}
