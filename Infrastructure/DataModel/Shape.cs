using System;
using System.Collections.Generic;
using System.Text;
using TetrisUI;

namespace Infrastructure.DataModel
{
    public abstract class Shape
    {
        protected bool[,] _shape;

        public int ShapeId { get; set; }
        public ShapeColor Color { get; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        protected Shape(int xPosition, int yPosition, ShapeColor color)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Color = color;
        }


        public List<Block> GetBlocks()
        {
            var blocks = new List<Block>();

            for (var y = 0; y < _shape.GetLength(1); y++)
            {
                for (var x = 0; x < _shape.GetLength(0); x++)
                {
                    if (_shape[y, x])
                    {
                        blocks.Add(new Block(x + XPosition, y + YPosition, Color));
                    }
                }
            }

            return blocks;
        }

    }
}
