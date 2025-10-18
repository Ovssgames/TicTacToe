using System;
using System.Linq;
using UnityEditor;

namespace _Project.Scripts
{
    public class CheckWinner
    {
        private int[,,] _winBoard = 
        {
            {{0,0},{0,1},{0,2}},
            {{1,0},{1,1},{1,2}},
            {{2,0},{2,1},{2,2}},
            {{0,0},{1,0},{2,0}},
            {{0,1},{1,1},{2,1}},
            {{0,2},{1,2},{2,2}},
            {{0,0},{1,1},{2,2}},
            {{0,2},{1,1},{2,0}}
        };

        public string Check(int[,] grid)
        {
            for (int i = 0; i < _winBoard.GetLength(0); i++)
            {
                int x1 = _winBoard[i, 0, 0], y1 = _winBoard[i, 0, 1];
                int x2 = _winBoard[i, 1, 0], y2 = _winBoard[i, 1, 1];
                int x3 = _winBoard[i, 2, 0], y3 = _winBoard[i, 2, 1];

                if (grid[x1, y1] == grid[x2, y2] && grid[x1, y1] == grid[x3, y3] && grid[x1, y1] != 0)
                {
                    if (grid[x1, y1] == -1) return "X";
                    if (grid[x1, y1] == 1) return "O";
                }
                    // return grid[x1, y1] == -1 ? "X" : "O";
            }

            foreach (var element in grid)
                if (element == 0)
                    return null;
            
            return "Draw";
        }
    }
}