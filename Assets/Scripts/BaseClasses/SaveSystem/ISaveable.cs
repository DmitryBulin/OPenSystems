using System.Collections.Generic;

namespace OPSystems.SaveSystem
{

    /// <summary>
    /// Interface for saveable classes. Class is to save and load certain type from dataChunks
    /// </summary>

    public interface ISaveable
    {
        void PopulateSave(Dictionary<int, ISaveChunk> dataChunks);
        void LoadData(Dictionary<int, ISaveChunk> dataChunks);
    }

}