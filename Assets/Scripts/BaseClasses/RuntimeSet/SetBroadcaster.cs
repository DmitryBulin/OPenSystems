using UnityEngine;

namespace OPSystems.RuntimeSet
{
    
    /// <summary>
    /// This is base class for automated listing/unlisting an object for a specific RuntimeSet in a form of component
    /// </summary>
    /// <typeparam name="T">
    /// Type to look for on an object
    /// </typeparam>
    
    public abstract class SetBroadcaster<T> : MonoBehaviour
    {
        [SerializeField] protected RuntimeSetSO<T> _runtimeSet;

        private void OnEnable()
        {
            foreach (T item in GetComponents<T>())
            {
                _runtimeSet.Add(item);
            }
        }

        private void OnDisable()
        {
            foreach (T item in GetComponents<T>())
            {
                _runtimeSet.Remove(item);
            }
        }

    }

}