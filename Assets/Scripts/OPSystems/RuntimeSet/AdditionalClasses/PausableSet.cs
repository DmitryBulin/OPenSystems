using UnityEngine;

namespace OPSystems.RuntimeSet
{

    /// <summary>
    /// This is class to interact with and store all of the gameplay objects that can be stopped
    /// </summary>

    [CreateAssetMenu(menuName = "OPSystems/Runtime Set/Pausable Set")]
    public class PausableSet : RuntimeSetSO<IPausable>
    {
        public void Pause()
        {
            foreach (IPausable item in Items)
            {
                item.Pause();
            }
        }

        public void Unpause()
        {
            foreach (IPausable item in Items)
            {
                item.Unpause();
            }
        }

    }

}