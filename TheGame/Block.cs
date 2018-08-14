using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisUI;

namespace TheGame
{
    public class Block
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public ShapeColor Color { get; set; }
        public bool IsFilled { get; set; }

        public Block(int xPosition, int yPosition, ShapeColor color)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            
        }

        public Block(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }
    }
}
