using Giroo.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts
{
#if UNITY_EDITOR

    public class LevelCreator : MonoBehaviour
    {
        [Button]
        public void Paint()
        {
            var settings = FindObjectOfType<GameInit>().settings;
            var blocks = FindObjectsOfType<Block>();

            foreach (var block in blocks)
            {
                var colorType = Random.Range(0, settings.blockMaterials.Count);
                block.SetMaterial(settings.blockMaterials[colorType]);
                block.blockColor = (BlockColor)colorType;
            }
        }
    }
#endif
}