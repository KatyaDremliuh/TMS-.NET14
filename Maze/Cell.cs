using System;

namespace Maze
{
    class Cell // клетка
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }
    }
}
