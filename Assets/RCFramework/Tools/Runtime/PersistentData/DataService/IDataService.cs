// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;

namespace RCFramework.Tools
{
    public interface IDataService
    {
        void Save<T>(T data, string saveSlot) where T : ISaveable;
        T Load<T>(string saveSlot) where T : ISaveable;
        void Delete<T>(string folderName) where T : ISaveable;
        void DeleteFolder(string folderName);
        void DeleteAll();
        IEnumerable<string> ListFolders();
        IEnumerable<string> ListFolderData(string saveSlot);
    }
}
