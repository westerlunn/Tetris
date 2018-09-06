using System;
using System.Collections.Generic;
using TetrisUI;

namespace Infrastructure.DataModel
{
    public class Block : IEquatable<Block>
    {
        public int Id { get; set; }
        //public int GameStateId { get; set; }
        //public GameState GameState { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public ShapeColor Color { get; set; }
        public bool IsFilled { get; set; }

        public Block()
        {
        }

        public Block(int xPosition, int yPosition, ShapeColor color, bool isFilled = true)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Color = color;
            IsFilled = isFilled;
        }

        public override bool Equals(object obj)
        {
            return obj is Block block &&
                   Id == block.Id;
        }

        public bool Equals(Block other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
