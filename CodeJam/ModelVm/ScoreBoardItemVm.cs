using System;

namespace CodeJam.ModelVm
{
    public class ScoreBoardItemVm
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
