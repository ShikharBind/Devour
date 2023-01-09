using UnityEngine;

namespace GameDev.Common
{
    [System.Serializable]
    public class JsonOps
    {
        public static string ConvertToJson(ISaveable a_saveData)
        {
            return JsonUtility.ToJson(a_saveData);
        }

        public static void LoadFromJson(string json, ISaveable a_saveData)
        {
            JsonUtility.FromJsonOverwrite(json, a_saveData);
        }
    }

    public interface ISaveable
    {
        // both uses file manager and JsonOps to load and store data
        void PopulateSaveData(ISaveable saveData);
        void LoadFromSaveData(ISaveable saveData);
    }
}