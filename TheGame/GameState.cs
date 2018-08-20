using System;
using System.Collections.Generic;

namespace TheGame
{
    public class GameState
    {

        public DateTime Time { get; set; }
        public Player Player { get; set; }
        public int Score { get; set; }  
        public Shape ActiveShape  { get; set; }
        public List<Block> DeadBlocks = new List<Block>(); //{ get; set; }

        public GameState()
        {
        }
    }
}
