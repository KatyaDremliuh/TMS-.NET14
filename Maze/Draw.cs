using System;
using System.Linq;

namespace Maze
{
    class Draw
    {
        public void DrawMaze(MazeLevel mazeLevel)
        {
            for (int yIndex = 0; yIndex < mazeLevel.Height; yIndex++)
            {
                for (int xIndex = 0; xIndex < mazeLevel.Width; xIndex++)
                {
                    Cell cell = mazeLevel.Cells
                        .First(cell => cell.X == xIndex && cell.Y == yIndex);

                    ConsoleColor oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = cell.Color;

                    Console.Write(cell.Symbol);
                    Console.ForegroundColor = oldColor;
                }

                Console.WriteLine();
            }
        }
    }
}
