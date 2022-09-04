using System.Collections.Generic;
using UnityEngine;

namespace OPSystems.RuntimeSet
{

    /// <summary>
    /// This is data structure to hold items of the same type for centralised access
    /// Example: List of pausable objects to pause/unpause the gameplay
    /// </summary>
    /// <typeparam name="T">
    /// Type to store
    /// </typeparam>

    public abstract class RuntimeSetSO<T> : ScriptableObject
    {
        public List<T> Items = new List<T>();

        public void Add(T item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
        }

        public void Remove(T item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }

    }
}