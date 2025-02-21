using Giroo.Core.Scriptables;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Giroo.Core
{
    public class LevelManager
    {
        private bool _isTest;
        private DataManager _dataManager;
        private GameManager _gameManager;

        private LevelData _levelData;
        private string _currentLevel;

        public LevelManager(bool isTest, DataManager dataManager, GameManager gameManager, LevelData levelData)
        {
            _isTest = isTest;
            _dataManager = dataManager;
            _gameManager = gameManager;
            _levelData = levelData;

            _gameManager.OnGameComplete += NextLevel;
            _gameManager.OnGameRestart += RestartLevel;
        }

        public void Init()
        {
            //Load first level
            if (_isTest)
            {
                _gameManager.GameLoaded();
                 
            }
            else
            {
                _gameManager.GameLoading();
                _currentLevel = _levelData.GetLevel(_dataManager.GetLevel());
                LoadAsync(_currentLevel);
            }
        }

        public void NextLevel()
        {
            _dataManager.LevelUp();
            var oldLevel = _currentLevel;
            _currentLevel = _levelData.GetLevel(_dataManager.GetLevel());
            UnloadAsync(oldLevel);
        }

        public void RestartLevel()
        {
            var oldLevel = _currentLevel;
            _currentLevel = _levelData.GetLevel(_dataManager.GetLevel());
            UnloadAsync(oldLevel);
        }

        public void LoadAsync(string level)
        {
            var async = SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
            async.completed += LoadComplete;
            _gameManager.GameLoading();
        }

        public void LoadComplete(AsyncOperation asyncOperation)
        {
            _gameManager.GameLoaded();
        }

        public void UnloadAsync(string level)
        {
            var async = SceneManager.UnloadSceneAsync(level);
            async.completed += UnloadComplete;
        }

        public void UnloadComplete(AsyncOperation asyncOperation)
        {
            LoadAsync(_currentLevel);
        }
    }
}