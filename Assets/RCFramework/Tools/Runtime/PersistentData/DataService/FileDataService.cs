// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Linq;

namespace RCFramework.Tools
{
    public class FileDataService : IDataService
    {
        private readonly ISerializer _serializer;
        private readonly string _dataPath;
        private readonly string _fileExtension;

        public FileDataService(ISerializer serializer, string fileExtension)
        {
            this._dataPath = Application.persistentDataPath;
            this._fileExtension = fileExtension;
            this._serializer = serializer;
        }

        void IDataService.Save<T>(T data, string folderName)
        {
            string slotPath = GetSlotPath(folderName);

            if (!Directory.Exists(slotPath))
            {
                Directory.CreateDirectory(slotPath);
            }

            string fileLocation = GetPathToFile(folderName, typeof(T).Name);

            string dataContent = _serializer.Serialize(data);
            File.WriteAllText(fileLocation, dataContent);
        }

        T IDataService.Load<T>(string folderName)
        {
            string fileLocation = GetPathToFile(folderName, typeof(T).Name);

            if (!File.Exists(fileLocation))
            {
                return default;
            }

            string fileContent = File.ReadAllText(fileLocation);
            return _serializer.Deserialize<T>(fileContent);
        }

        void IDataService.Delete<T>(string folderName)
        {
            string fileLocation = GetPathToFile(folderName, typeof(T).Name);
            
            if (File.Exists(fileLocation))
            {
                File.Delete(fileLocation);
            }
        }

        void IDataService.DeleteFolder(string folderName)
        {
            string slotPath = GetSlotPath(folderName);

            if (Directory.Exists(slotPath))
            {
                Directory.Delete(slotPath, true);
            }
        }

        void IDataService.DeleteAll()
        {
            foreach (string dirPath in Directory.GetDirectories(_dataPath))
            {
                Directory.Delete(dirPath, true);
            }
        }

        IEnumerable<string> IDataService.ListFolders()
        {
            return Directory.GetDirectories(_dataPath).Select(Path.GetFileName);
        }

        IEnumerable<string> IDataService.ListFolderData(string folderName)
        {
            string slotPath = GetSlotPath(folderName);

            if (!Directory.Exists(slotPath))
            {
                yield break;
            }

            foreach (string path in Directory.EnumerateFiles(slotPath))
            {
                if (Path.GetExtension(path) == $".{_fileExtension}")
                {
                    yield return Path.GetFileNameWithoutExtension(path);
                }
            }
        }

        private string GetSlotPath(string saveSlot)
        {
            return Path.Combine(_dataPath, saveSlot);
        }

        private string GetPathToFile(string saveSlot, string fileName)
        {
            return Path.Combine(GetSlotPath(saveSlot), string.Concat(fileName, ".", _fileExtension));
        }
    }
}
