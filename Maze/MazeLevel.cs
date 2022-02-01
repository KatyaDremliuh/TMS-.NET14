using System.Collections.Generic;

namespace Maze
{
    class MazeLevel
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public List<Cell> Cells { get; set; }
    }
}
