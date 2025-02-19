using Sirenix.OdinInspector;
using UnityEngine;

namespace Giroo.Core.Grid
{
    public class WorldGrid : MonoBehaviour
    {
        [BoxGroup("Grid Settings")] public int width = 10;
        [BoxGroup("Grid Settings")] public int height = 10;
        [BoxGroup("Grid Settings")] public float cellSize = 1f;
        [BoxGroup("Grid Settings")] public float cellPadding = 0.1f;
        [BoxGroup("Grid Settings")] public Vector3 offset = Vector3.zero;

        private Grid<GridData> _grid = new Grid<GridData>(10, 10);

        private Transform _transform;
        
        
        private Vector3 GetWorldPosition(int x, int y)
        {
            Vector3 rightVector = _transform.right;
            Vector3 upVector = _transform.up;
            Vector3 cellPaddingVector = rightVector * cellPadding * (x - 1) + upVector * cellPadding * (y - 1);
            Vector3 startPoint = _transform.position + offset + rightVector * cellSize * 0.5f + upVector * cellSize * 0.5f + rightVector * cellPadding + upVector * cellPadding;
            return rightVector * x * cellSize + upVector * y * cellSize + startPoint + cellPaddingVector;
        }

        private Vector2Int WorldPosToGridPos(Vector3 vector3)
        {
            

            return Vector2Int.zero;
        }

        private void OnDrawGizmos()
        {
            if (_transform == null)
            {
                _transform = transform;
            }

            Gizmos.color = Color.black;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector3 worldPoint = GetWorldPosition(x, y);
                    Gizmos.DrawWireCube(worldPoint, new Vector3(cellSize, cellSize, 0.1f));
                }
            }
        }
    }
}