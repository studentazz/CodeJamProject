using System;
using System.Linq;
using CodeJam.Interfaces;

namespace CodeJam.Service
{
    public class ProblemContainer
    {
        public readonly IProblem[] Problems =
        {
            new Problem1(),
            new Problem2()
        };

        public bool IsProblemSolved(string problemId, string answer)
        {
            var problem = Problems.FirstOrDefault(p => p.Id.Equals(problemId, StringComparison.OrdinalIgnoreCase));
            if (problem == null)
            {
                throw new ArgumentException($"Problem implementation with an id: {nameof(problemId)} wasn't found.");
            }

            return problem.IsSoved(answer);
        }
    }
}
