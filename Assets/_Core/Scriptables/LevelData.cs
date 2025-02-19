using System.Collections.Generic;
using UnityEngine;

namespace Giroo.Core.Scriptables
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Core/LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        public List<string> levels;

        public string GetLevel(int index)
        {
            int levelIndex = (index - 1) % levels.Count;
            return levels[levelIndex];
        }
    }
}