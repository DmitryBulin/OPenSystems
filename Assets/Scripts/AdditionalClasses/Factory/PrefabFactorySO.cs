using UnityEngine;

namespace OPSystems.Factory
{

    /// <summary>
    /// Factory for creating prefab object
    /// Example: Creating pickup objects
    /// </summary>

    [CreateAssetMenu(menuName = "OPSystems/Factory/Prefab Factory")]
    public class PrefabFactorySO : FactorySO<GameObject>
    {
        [SerializeField] private GameObject _prefab;

        public override GameObject Create()
        {
            return Instantiate(_prefab);
        }

    }

}