using UnityEngine;

namespace Giroo.Core
{
    public class DataManager
    {
        public Data GameData;


        public void Init()
        {
            Load();
            Debug.Log("Data Initialized!");
        }

        #region SaveLoad
        public void Save()
        {
            string _toSave = JsonUtility.ToJson(GameData);
            PlayerPrefs.SetString("Save", _toSave);
        }

        public void Load()
        {
            string _toLoad = PlayerPrefs.GetString("Save");
            if (_toLoad == "") _toLoad = null;

            if (_toLoad != null)
            {
                GameData = JsonUtility.FromJson<Data>(_toLoad);
            }
            else
            {
                GameData = new Data();
            }
        }

        #endregion

        public void LevelUp()
        {
            GameData.level += 1;
            Save();
        }

        public int GetLevel()
        {
            return GameData.level;
        }
    }

    public class Data
    {
        public int level = 1;
    }
}