using System;
using System.Collections.Generic;
using Giroo.Core.Scriptables;
using Giroo.Core.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Giroo.Core
{
    public class GameInit : MonoBehaviour
    {
        [BoxGroup("References")] public Settings settings;
        [BoxGroup("References")] public LevelData levelData;
        [BoxGroup("References")] public UIController uiController;
        [BoxGroup("Test Settings")] public bool isTest;


        private List<IUpdateable> _updateables = new List<IUpdateable>();

        public void OnEnable()
        {
            Init();
        }

        public void Init()
        {
            //Manager creation
            DataManager dataManager = new DataManager();
            GameManager gameManager = new GameManager();
            LevelManager levelManager = new LevelManager(isTest, dataManager, gameManager, levelData);
            EventManager eventManager = new EventManager();
            VibrationManager vibrationManager = new VibrationManager();

            //Manager initialization
            Game.Initialize(settings, uiController, dataManager, gameManager, levelManager, eventManager, vibrationManager);
            uiController.Init();

            //Updateables add to list 
            _updateables.Add(vibrationManager);
        }

        public void Update()
        {
            foreach (var updateable in _updateables)
            {
                updateable.Update(Time.deltaTime);
            }
        }
    }
}