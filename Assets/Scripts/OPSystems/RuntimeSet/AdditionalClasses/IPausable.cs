namespace OPSystems.RuntimeSet
{

    /// <summary>
    /// Interface for gameplay objects that should be stopped whenever game is paused
    /// </summary>

    public interface IPausable
    {
        void Pause();
        void Unpause();
    }


}
