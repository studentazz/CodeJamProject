using System;

namespace CodeJam.Repository
{
    public class AnswerOut
    {
        public string Nickname { get; set; }

        public string TaskId { get; set; }

        public bool IsCorrect { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTimeOffset SubmitDate => new DateTimeOffset(CreatedDate, TimeSpan.Zero);
    }
}