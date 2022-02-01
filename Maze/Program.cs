using System;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeBuilder builder = new();
            Draw draw = new();

            MazeLevel maze = builder.BuildSmallStandart();
            draw.DrawMaze(maze);
        }
    }
}
