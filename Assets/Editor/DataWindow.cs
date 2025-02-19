using Giroo.Core;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace Giroo.Core.Editor
{
    public class DataWindow : OdinEditorWindow
    {
        [BoxGroup("DATA WINDOW")]
        [HideLabel]
        [Searchable]
        public Data gameData;
		
        private DataManager _dataManager;

        [MenuItem("RoofTop Games/DataWindow")]
        private static void OpenWindow()
        {
            var window = GetWindow<DataWindow>();
            window.Show();
        }

        private void OnFocus()
        {
            _dataManager = new DataManager();
            gameData = _dataManager.GameData;
        }

        [Button(ButtonSizes.Medium)]
        public void Save()
        {
            _dataManager.Save();	
        }
    }
}