using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Giroo.Core.Grid
{
    public class Grid<T>
    {
        private T[,] _grid;

        public Grid(int width, int height)
        {
            _grid = new T[width, height];
        }

        public T this[int x, int y]
        {
            get
            {
                if (IsInBounds(x, y))
                {
                    return _grid[x, y];
                }
                else
                {
                    return default(T);
                }
            }
            set
            {
                if (IsInBounds(x, y))
                {
                    _grid[x, y] = value;
                }
                else
                {
                    Debug.Log("Index out of bounds!");
                }
            }
        }

        public T this[Vector2Int index]
        {
            get
            {
                if (IsInBounds(index.x, index.y))
                {
                    return _grid[index.x, index.y];
                }
                else
                {
                    return default(T);
                }
            }
            set
            {
                if (IsInBounds(index.x, index.y))
                {
                    _grid[index.x, index.y] = value;
                }
                else
                {
                    Debug.Log("Index out of bounds!");
                }
            }
        }

        private T GetGridObject(int x, int y)
        {
            if (IsInBounds(x, y))
            {
                return _grid[x, y];
            }
            else
            {
                return default(T);
            }
        }

        private void SetGridObject(int x, int y, T value)
        {
            if (IsInBounds(x, y))
            {
                _grid[x, y] = value;
            }
            else
            {
                Debug.Log("Index out of bounds!");
            }
        }

        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && y >= 0 && x < _grid.GetLength(0) && y < _grid.GetLength(1);
        }
    }

    public class GridData
    {
        public int data;
    }

}

