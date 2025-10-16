// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using RCFramework.Core;
using System.Collections.Generic;

namespace RCFramework.Tools
{
    public class PersistentStorage : IUtility
    {
        private readonly IDataService _dataService;
        private const string _defaultExtension = "sav";

        public PersistentStorage(bool encrypted = false, string keyString = null)
        {
            ISerializer serializer = encrypted ? new JsonEncryptedSerializer(keyString) : new JsonSerializer();
            _dataService = new FileDataService(serializer, _defaultExtension);
        }

        public void Save<T>(T data, string folderName) where T : ISaveable
        {
            _dataService.Save(data, folderName);
        }

        public T Load<T>(string folderName) where T : ISaveable
        {
            return _dataService.Load<T>(folderName);
        }

        public void Delete<T>(string folderName) where T : ISaveable
        {
            _dataService.Delete<T>(folderName);
        }

        public void DeleteFolder(string folderName)
        {
            _dataService.DeleteFolder(folderName);
        }

        public void DeleteAll()
        {
            _dataService.DeleteAll();
        }

        public IEnumerable<string> ListFolders()
        {
            return _dataService.ListFolders();
        }

        public IEnumerable<string> ListFolderData(string folderName)
        {
            return _dataService.ListFolderData(folderName);
        }
    }
}
