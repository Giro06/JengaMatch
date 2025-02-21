using System;
using UnityEngine;

namespace _Scripts
{
    public class InputSystem : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    var block = hit.collider.GetComponent<Block>();
                    if (block != null)
                    {
                        FindObjectOfType<LevelCreator>().RemoveBlockColor(block.blockColor);

                        block.Disolve();
                    }
                }
            }
        }
    }
}