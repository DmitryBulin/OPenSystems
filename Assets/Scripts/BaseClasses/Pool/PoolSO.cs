using System.Collections.Generic;
using UnityEngine;
using OPSystems.Factory;

namespace OPSystems.Pool
{

    /// <summary>
    /// Implements IPool interface in a form of ScriptableObject entity
    /// </summary>
    /// <typeparam name="T">
    /// Specifies a type of elements to store
    /// </typeparam>

    public abstract class PoolSO<T> : ScriptableObject, IPool<T>
    {
        protected Stack<T> _available = new Stack<T>();
        protected bool _hasBeenPrewarmed;

        /// <summary>
        /// This factory will be used to create new <typeparamref name="T"/> on demand
        /// </summary>
        
        protected abstract IFactory<T> Factory { get; set; }

        /// <summary>
        /// Creates a <typeparamref name="T"/> on demand from pool
        /// </summary>
        /// <returns>
        /// Created <typeparamref name="T"/>
        /// </returns>

        protected virtual T Create()
        {
            return Factory.Create();
        }

        /// <summary>
        /// Prewarms a pool with a <paramref name="num"/> of <typeparamref name="T"/>
        /// </summary>
        /// <param name="num">
        /// Number of members in prewarm
        /// </param>
        /// <remarks>
        /// NOTE: This method can be called only once for the lifetime of the pool
        /// </remarks>

        public virtual void Prewarm(int num)
        {
            if (_hasBeenPrewarmed)
            {
                Debug.LogWarning("Pool " + name + " has already been prewarmed");
                return;
            }

            for (int i = 0; i < num; ++i)
            {
                _available.Push(Create());
            }

            _hasBeenPrewarmed = true;
        }

        /// <summary>
        /// Requests a <typeparamref name="T"/> from this pool
        /// </summary>
        /// <returns>
        /// Requested <typeparamref name="T"/>
        /// </returns>

        public virtual T Request()
        {
            return _available.Count > 0 ? _available.Pop() : Create();
        }

        /// <summary>
        /// Requests a <typeparamref name="T"/> collection from this pool 
        /// </summary>
        /// <param name="num">
        /// Collection size
        /// </param>
        /// <returns>
        /// Requested <typeparamref name="T"/> collection
        /// </returns>

        public virtual IEnumerable<T> Request(int num = 1)
        {
            List<T> members = new List<T>();
            for (int i = 0; i < num; ++i)
            {
                members.Add(Request());
            }
            return members;
        }

        /// <summary>
        /// Return a <typeparamref name="T"/> to the pool
        /// </summary>
        /// <param name="member">
        /// A <typeparamref name="T"/> to return
        /// </param>

        public virtual void Return(T member)
        {
            _available.Push(member);
        }

        /// <summary>
        /// Returns a <typeparamref name="T"/> collection to the pool
        /// </summary>
        /// <param name="members">
        /// A <typeparamref name="T"/> collection to return
        /// </param>

        public virtual void Return(IEnumerable<T> members)
        {
            foreach (T member in members)
            {
                Return(member);
            }
        }
        
        private void OnDisable()
        {
            _available.Clear();
            _hasBeenPrewarmed = false;
        }

    }

}
