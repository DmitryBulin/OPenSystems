using UnityEngine;
using OPSystems.Events;
using OPSystems.FileManagement;

namespace OPSystems.SaveSystem
{

    /// <summary>
    /// This is class to manage loading and unloading of a gameplay savings
    /// Example: Roguelike-like three saves system
    /// </summary>

    public class SaveManager : MonoBehaviour
    {
        [SerializeField] private string _gameplaySaveFolder = "";
        public SaveDataSO CurrentGameplaySave { get; set; }
        [Header("Listening to")]
        [SerializeField] private EventChannelBase _gameplaySaveChannel = default;
        [SerializeField] private EventChannelBase _gameplayLoadChannel = default;
        [Header("Broadcasting on")]
        [SerializeField] private EventChannelBase<bool> _savingResultChannel = default;
        [SerializeField] private EventChannelBase<bool> _loadingResultChannel = default;

        private void OnEnable()
        {
            _gameplaySaveChannel.OnEventRaised += SaveData;
            _gameplayLoadChannel.OnEventRaised += LoadData;
        }

        private void OnDisable()
        {
            _gameplaySaveChannel.OnEventRaised -= SaveData;
            _gameplayLoadChannel.OnEventRaised -= LoadData;
        }

        public void SaveData()
        {
            string dataToSave = CurrentGameplaySave.ToJson();
            bool saveResult = FileManager.SaveFile(CurrentGameplaySave.FileName, dataToSave, _gameplaySaveFolder);
            _savingResultChannel.Raise(saveResult);
        }

        public void LoadData()
        {
            bool loadResult = FileManager.LoadFromFile(CurrentGameplaySave.FileName, out string dataFromFile, _gameplaySaveFolder);
            CurrentGameplaySave.LoadFromJson(dataFromFile);
            _loadingResultChannel.Raise(loadResult);
        }

    }

}