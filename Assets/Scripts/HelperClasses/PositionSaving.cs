using System.Collections.Generic;
using UnityEngine;

namespace OPSystems.SaveSystem
{

    /// <summary>
    /// This is component to put on the object to save it's position 
    /// </summary>

    public class PositionSaving : MonoBehaviour, ISaveable
    {
        [SerializeField] private int _objectID;

        [System.Serializable]
        public struct PositionChunk : ISaveChunk
        {
            public Vector3 position;
        }

        public void PopulateSave(Dictionary<int, ISaveChunk> dataChunks)
        {
            dataChunks[_objectID] = new PositionChunk()
            {
                position = transform.position
            };
        }

        public void LoadData(Dictionary<int, ISaveChunk> dataChunks)
        {
            if (dataChunks.ContainsKey(_objectID))
            {
                PositionChunk dataChunk = (PositionChunk)dataChunks[_objectID];
                transform.position = dataChunk.position;
            }
        }

    }

}