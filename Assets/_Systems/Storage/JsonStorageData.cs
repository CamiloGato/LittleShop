using System.IO;
using UnityEngine;

namespace Storage
{
    public class JsonStorageData : IStorageData
    {
        private DataConfiguration _dataConfiguration;
        
        public T GetData<T>() where T : new()
        {
            if (!File.Exists(_dataConfiguration.UserDataFile))
            {
                return default(T);
            }
        
            string json = File.ReadAllText(_dataConfiguration.UserDataFile);
            T data = JsonUtility.FromJson<T>(json);
            return data;
        }

        public void SaveData<T>(T data) where T : new()
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(_dataConfiguration.UserDataFile, json);
        }
    }
    
}