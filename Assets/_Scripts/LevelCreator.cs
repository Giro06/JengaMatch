using System.Collections.Generic;
using System.Linq;
using Giroo.Core;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class LevelCreator : MonoBehaviour
    {
        public GameObject layerPrefab;
        public List<Layer> layers;
        public List<Block> blockList;
#if UNITY_EDITOR

        [Button]
        public void CreateTower(int height)
        {
            for (int i = 0; i < height; i++)
            {
                var layer = Instantiate(layerPrefab, new Vector3(0, i * 0.5f, 0), Quaternion.identity)
                    .GetComponent<Layer>();

                if (i % 2 == 0)
                {
                    layer.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
            }
        }

        [Button]
        public void GetLayers()
        {
            this.layers = new List<Layer>();
            var layers = FindObjectsOfType<Layer>();
            foreach (var l in layers)
            {
                l.blockList = new List<Block>();
                foreach (var block in l.GetComponentsInChildren<Block>())
                {
                    l.blockList.Add(block);
                }

                this.layers.Add(l);
            }
        }

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

        [Button]
        public void CreateTargetBlockList(int layerPercentage)
        {
            blockList = new List<Block>();
            foreach (var layer in layers)
            {
                var randomValue = Random.Range(0, 100);

                if (randomValue < layerPercentage)
                {
                    var randomInOrOut = Random.Range(0, 2);

                    if (randomInOrOut == 0)
                    {
                        blockList.Add(layer.blockList[0]);
                        blockList.Add(layer.blockList[2]);
                    }
                    else
                    {
                        blockList.Add(layer.blockList[1]);
                    }
                }
            }

            blockList = blockList.OrderBy(x => x.blockColor).ToList();
        }

#endif

        public void RemoveBlockColor(BlockColor blockColor)
        {
            var block = blockList.FirstOrDefault(x => x.blockColor == blockColor);
            if (block != null)
            {
                blockList.Remove(block);
            }

            if (!blockList.Any())
            {
                Game.uiController.OpenGameSuccess();
            }
        }
    }
}