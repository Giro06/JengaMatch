using Giroo.Core.Scriptables;
using Giroo.Core.UI;

namespace Giroo.Core
{
    public static class Game
    {
        public static Settings settings { get; private set; }

        public static UIController uiController { get; private set; }

        //Managers
        public static DataManager dataManager { get; private set; }
        public static GameManager gameManager { get; private set; }
        public static LevelManager levelManager { get; private set; }

        public static EventManager eventManager { get; private set; }

        public static VibrationManager vibrationManager { get; private set; }

        public static void Initialize(Settings settings, UIController uiController, DataManager dataManager, GameManager gameManager, LevelManager levelManager, EventManager eventManager, VibrationManager vibrationManager)
        {
            Game.settings = settings;
            Game.uiController = uiController;

            Game.dataManager = dataManager;
            Game.gameManager = gameManager;
            Game.levelManager = levelManager;
            Game.eventManager = eventManager;
            Game.vibrationManager = vibrationManager;

            //Init Managers
            dataManager.Init();
            levelManager.Init();
        }
    }
}