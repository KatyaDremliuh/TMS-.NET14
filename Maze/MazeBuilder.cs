using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    class MazeBuilder
    {
        public MazeLevel Build(int width = 5, int height = 7)
        {
            MazeLevel mazeLevel = GetBaseMaze(width, height);

            for (int y = 0; y < mazeLevel.Height; y++)
            {
                for (int x = 0; x < mazeLevel.Width; x++)
                {
                    Cell cell = new Cell()
                    {
                        X = x,
                        Y = y,
                        Color = ConsoleColor.DarkGreen,
                        Symbol = '#'
                    };

                    if ((x+y)%3==1)
                    {
                        cell.Symbol = '@';
                        cell.Color = ConsoleColor.Blue;
                    }

                    mazeLevel.Cells.Add(cell);
                }
            }

            return mazeLevel;
        }

        public MazeLevel BuildSmallStandart()
        {
            MazeLevel mazeLevel = GetBaseMaze(3, 3);

            for (int y = 0; y < mazeLevel.Height; y++)
            {
                for (int x = 0; x < mazeLevel.Width; x++)
                {
                    Cell cell = new Cell()
                    {
                        X = x,
                        Y = y,
                        Symbol = '_',
                        Color = ConsoleColor.DarkRed,
                    };

                    mazeLevel.Cells.Add(cell);
                }
            }

            Cell firstCell = mazeLevel.Cells
                .First(cell => cell.X == 1 && cell.Y == 0);
            firstCell.Symbol = '#';

            Cell secondCell = mazeLevel.Cells
                .First(cell => cell.X == 1 && cell.Y == 2);
            secondCell.Symbol = '#';

            return mazeLevel;
        }

        private MazeLevel GetBaseMaze(int width, int height)
        {
            MazeLevel mazeLevel = new MazeLevel();

            mazeLevel.Width = width;
            mazeLevel.Height = height;
            mazeLevel.Cells = new List<Cell>();

            return mazeLevel;
        }
    }
}
