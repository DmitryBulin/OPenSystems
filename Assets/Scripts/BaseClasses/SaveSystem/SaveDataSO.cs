using System.Collections.Generic;
using UnityEngine;
using OPSystems.RuntimeSet;
using Newtonsoft.Json;

namespace OPSystems.SaveSystem
{

    /// <summary>
    /// This class represents single save file. It saves to and loads from passed json file
    /// </summary>
    /// <remarks>
    /// NOTE: For json serialization and deserialization used Newtonsoft's Json.NET framework
    /// </remarks>

    [CreateAssetMenu(menuName = "OPSystems/Save System/Save Data")]
    public class SaveDataSO : ScriptableObject
    {
        [Tooltip("This name will be used as a FileName.dat")] public string FileName;
        [SerializeField] private SaveableSet _saveableItems;
        private Dictionary<int, ISaveChunk> _saveChunks = new Dictionary<int, ISaveChunk>();

        public string ToJson()
        {
            _saveableItems.SaveData(_saveChunks);
            string json = JsonConvert.SerializeObject(_saveChunks, Formatting.Indented, new JsonSerializerSettings
            {
                // To not loop while saving Vector3
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                // To keep types and not loose them due to interfacing 
                TypeNameHandling = TypeNameHandling.All
            });
            return json;
        }

        public void LoadFromJson(string json)
        {
            _saveChunks = JsonConvert.DeserializeObject<Dictionary<int, ISaveChunk>>(json, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                // To load corresponding data types
                TypeNameHandling = TypeNameHandling.All
            });
            _saveableItems.LoadData(_saveChunks);
        }

    }


}