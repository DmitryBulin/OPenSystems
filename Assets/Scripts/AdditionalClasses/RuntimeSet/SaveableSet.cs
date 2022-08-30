using System.Collections.Generic;
using UnityEngine;
using OPSystems.SaveSystem;

namespace OPSystems.RuntimeSet
{

    [CreateAssetMenu(menuName = "OPSystems/Runtime Set/Saveable Set")]
    public class SaveableSet : RuntimeSetSO<ISaveable>
    {
        public void SaveData(Dictionary<int, ISaveChunk> dataChunks)
        {
            foreach (ISaveable item in Items)
            {
                item.PopulateSave(dataChunks);
            }
        }

        public void LoadData(Dictionary<int, ISaveChunk> dataChunks)
        {
            foreach (ISaveable item in Items)
            {
                item.LoadData(dataChunks);
            }
        }

    }

}