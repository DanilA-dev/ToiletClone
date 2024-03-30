using System;
using System.IO;
using UnityEngine;

namespace Systems.DataServiceSystem
{
    public class JSONDataService : IDataService
    {
        public bool Save<T>(string path, T data)
        {
            var relativePath = Application.persistentDataPath + path + ".json";
            try
            {
                if(File.Exists(relativePath))
                    OverwriteSaveFile(path, data, relativePath);
                else
                    SaveNewFile(path, data, relativePath);

                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Can't write to file {relativePath}, info{e}");
                return false;
            }
        }

        private void SaveNewFile<T>(string path, T data, string relativePath)
        {
            Debug.Log($"New save file,writing file {relativePath}");
            using FileStream stream = File.Create(relativePath);
            stream.Close();
            File.WriteAllText(path, JsonUtility.ToJson(data));
        }

        private void OverwriteSaveFile<T>(string path, T data, string relativePath)
        {
            Debug.Log($"Save file exists,overwriting file {relativePath}");
            File.Delete(relativePath);
            using FileStream stream = File.Create(relativePath);
            stream.Close();
            File.WriteAllText(path, JsonUtility.ToJson(data));
        }

        public T Load<T>(string path)
        {
            var relativePath = Application.persistentDataPath + path;
            if (!File.Exists(relativePath))
            {
                Debug.Log($" <color=red> File does not exist {relativePath} </color>");
                throw new FileNotFoundException($"{path} does not exist");
            }

            try
            {
                var file = File.ReadAllText(relativePath);
                var data = JsonUtility.FromJson<T>(file);
                return data;
            }
            catch (Exception e)
            {
                Debug.LogError($"Can't load file {relativePath}, info{e}");
                throw;
            }
        }
    }
}