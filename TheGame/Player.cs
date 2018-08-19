using System;

namespace TheGame
{
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public long Highscore { get; set; }
        public long Score { get; set; }

        public Player(string username, int score = 0)
        {
            Username = username;
        }

        public Player()
        {
        }
    }
}