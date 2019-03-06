using System;
using System.Linq;
using CodeJam.Problems;

namespace CodeJam.Service
{
    public class CheckAnswers
    {
        private readonly IProblem[] _problems =
        {
            new SnowWhiteProblem()
        };

        public bool IsAnswerCorrect(string taskId, string answer)
        {
            var problem = _problems.FirstOrDefault(p => p.TaskId.Equals(taskId, StringComparison.OrdinalIgnoreCase));
            if (problem == null) throw new ArgumentException(nameof(taskId));

            return problem.CheckOutput(answer);
        }
    }
}
