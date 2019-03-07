using System;

namespace CodeJam.ModelIn
{
    public class ScoreBoardItem
    {
        public string Username { get; set; }
        public int Score { get; set; }
        public TimeSpan Penalty { get; set; }

        public bool SnowwhiteSolved { get; set; }
        public int SnowwhiteIncorrectAttempts { get; set; }
        public TimeSpan? SnowwhiteSolvingTime { get; set; }

        public bool ElectionSolved { get; set; }
        public int ElectionIncorrectAttempts { get; set; }
        public TimeSpan? ElectionSolvingTime { get; set; }
    }
}
