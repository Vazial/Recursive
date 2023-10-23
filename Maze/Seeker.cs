using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive.Maze
{
    public class Seeker
    {
        private static readonly int[,] Directions = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };

        public static Cell Seek(CellInfo[,] maze, int PosX = 1, int PosY = 1)
        {
            for (int ii = 0; ii < Directions.GetLength(0); ++ii)
            {
                var X = PosX + Directions[ii, 0];
                var Y = PosY + Directions[ii, 1];
                if (maze[X, Y] == CellInfo.Path) 
                {
                    maze[X, Y] = CellInfo.InCollect;
                    var result = Seek(maze, X, Y);
                    if (result is not null) 
                    {
                        maze[X, Y] = CellInfo.Collect;
                        return result; 
                    }
                }
                if (maze[X, Y] == CellInfo.End)
                {
                    var EndCell = new Cell();
                    EndCell.X = X;
                    EndCell.Y = Y;
                    return EndCell;
                }
            }
            return null;
        }
    }
}
