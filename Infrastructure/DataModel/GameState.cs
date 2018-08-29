using System;
using System.Collections.Generic;

namespace Infrastructure.DataModel
{
    public class GameState
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public Player Player { get; set; }
        public long Score { get; set; }
        public int ActiveShapeId { get; set; }
        public Shape ActiveShape  { get; set; }
        public List<Block> DeadBlocks { get; set; } = new List<Block>(); 

        public GameState()
        {
        }


    }
}
