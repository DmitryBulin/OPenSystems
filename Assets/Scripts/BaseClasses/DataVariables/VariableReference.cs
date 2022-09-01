using UnityEngine;

namespace OPSystems
{

    /// <summary>
    /// Flexible handle for using either Variable or constant value
    /// </summary>
    /// <typeparam name="T">
    /// Type of value
    /// </typeparam>

    [System.Serializable]
    public class VariableReference<T>
    {
        [SerializeField] private bool _useConstant;
        [SerializeField] private T _constantValue;
        [SerializeField] private VariableSO<T> _variable;

        public T Value
        {
            get { return _useConstant ? _constantValue : _variable.Value; }
            set
            {
                if (_useConstant)
                {
                    _constantValue = value;
                }
                else
                {
                    _variable.Value = value;
                }
            }
        }

    }

}