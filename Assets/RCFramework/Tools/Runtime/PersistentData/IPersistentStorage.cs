// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using RCFramework.Core;
using System.Collections.Generic;

namespace RCFramework.Tools
{
    public interface IPersistentStorage : IUtility
    {
        void Save<T>(T data, string folderName) where T : ISaveable;

        public T Load<T>(string folderName) where T : ISaveable;

        void Delete<T>(string folderName) where T : ISaveable;

        public void DeleteFolder(string folderName);

        public void DeleteAll();

        public IEnumerable<string> ListFolders();

        public IEnumerable<string> ListFolderData(string folderName);
    }
}