using UnityEngine;
using System.IO;
using System;

namespace OPSystems.FileManagement
{

    /// <summary>
    /// This is a simple static class for reading and writing from files
    /// </summary>

    public static class FileManager
    {

        private static string CombinePath(string fileName, string folderName)
        {
            return Path.Combine(Application.persistentDataPath, folderName, fileName + ".dat");
        }

        public static bool CheckFileExistence(string fileName, string folderName = "")
        {
            string fullFilePath = CombinePath(fileName, folderName);

            return File.Exists(fullFilePath);
        }

        public static bool SaveFile(string fileName, string fileData, string folderName = "")
        {
            string folderPath = Path.Combine(Application.persistentDataPath, folderName);
            string fullFilePath = Path.Combine(folderPath, fileName + ".dat");

            Directory.CreateDirectory(folderPath);

            try
            {
                File.WriteAllText(fullFilePath, fileData);
                Debug.Log("Saved file to " + fullFilePath);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to write to " + fullFilePath + " with exception " + e);
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out string fileData, string folderName = "")
        {
            string fullFilePath = CombinePath(fileName, folderName);

            try
            {
                fileData = File.ReadAllText(fullFilePath);
                Debug.Log("Loaded file from " + fullFilePath);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to read from " + fullFilePath + " with exception " + e);
                fileData = "";
                return false;
            }
        }

    }

}