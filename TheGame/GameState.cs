using System;
using System.Collections.Generic;

namespace TheGame
{
    public class GameState
    {

        public DateTime Time { get; set; }
        public Player Player { get; set; }
        public int Score { get; set; }  
        public Shape ActiveShape { get; set; }
        public List<Block> DeadBlocks { get; set; }

        public GameState(int score, Shape activeShape, List<Block> deadBlocks)
        {
            Score = score;
            ActiveShape = activeShape;
            DeadBlocks = deadBlocks;
        }

        public GameState(DateTime time, Player player, int score, Shape activeShape, List<Block> deadBlocks)
        {
            Time = time;
            Player = player;
            Score = score;
            ActiveShape = activeShape;
            DeadBlocks = deadBlocks;
        }
        public GameState()
        {
        }

    }
}
