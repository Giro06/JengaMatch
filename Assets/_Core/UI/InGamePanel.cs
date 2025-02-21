using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Giroo.Core.UI
{
    public class InGamePanel : MonoBehaviour
    {
        public TMP_Text levelText;
        public List<Image> stageImages;

        public void Start()
        {
            int currentLevel = Game.dataManager.GameData.level;
            levelText.text = "Level " + currentLevel;
        }
    }
}