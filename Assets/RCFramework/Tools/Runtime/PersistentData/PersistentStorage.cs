// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;

namespace RCFramework.Tools
{
    public class PersistentStorage : IPersistentStorage
    {
        private readonly IDataService _dataService;
        private const string _defaultExtension = "sav";

        public PersistentStorage(bool encrypted = false, string keyString = null)
        {
            ISerializer serializer = encrypted ? new JsonEncryptedSerializer(keyString) : new JsonSerializer();
            _dataService = new FileDataService(serializer, _defaultExtension);
        }

        void IPersistentStorage.Save<T>(T data, string folderName)
        {
            _dataService.Save(data, folderName);
        }

        T IPersistentStorage.Load<T>(string folderName)
        {
            return _dataService.Load<T>(folderName);
        }

        void IPersistentStorage.Delete<T>(string folderName)
        {
            _dataService.Delete<T>(folderName);
        }

        void IPersistentStorage.DeleteFolder(string folderName)
        {
            _dataService.DeleteFolder(folderName);
        }

        void IPersistentStorage.DeleteAll()
        {
            _dataService.DeleteAll();
        }

        IEnumerable<string> IPersistentStorage.ListFolders()
        {
            return _dataService.ListFolders();
        }

        IEnumerable<string> IPersistentStorage.ListFolderData(string folderName)
        {
            return _dataService.ListFolderData(folderName);
        }
    }
}