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
            answer = answer.Trim(new char[] { '\r', '\n', ' '  });
            switch (taskId)
            {
                case "snieguole":
                    break;
                case "dazymas":
                    string correct = 
@"5
5
101
102
5003
261060
25665";
                    if (correct == answer)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }

            return false;
            var problem = _problems.FirstOrDefault(p => p.TaskId.Equals(taskId, StringComparison.OrdinalIgnoreCase));
            if (problem == null) throw new ArgumentException(nameof(taskId));

            return problem.CheckOutput(answer);
        }
    }
}
