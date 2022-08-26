using UnityEngine;
using OPSystems.Factory;

namespace OPSystems.Pool
{

    /// <summary>
    /// Pool for GameObjects with specified factory 
    /// and root for objects in pool
    /// </summary>

    [CreateAssetMenu(menuName = "OPSystems/Pool/Prefab pool")]
    public class PrefabPoolSO : PoolSO<GameObject>
    {
        [SerializeField] private Transform _poolRoot;
        [SerializeField] private FactorySO<GameObject> _poolFactory;

        public override GameObject Request()
        {
            GameObject member = base.Request();
            member.SetActive(true);
            return member;
        }

        protected override IFactory<GameObject> Factory
        {
            get => _poolFactory;
            set => _poolFactory = value as FactorySO<GameObject>;
        }

        protected override GameObject Create()
        {
            GameObject newMember = base.Create();
            newMember.transform.SetParent(_poolRoot);
            return newMember;
        }

    }

}