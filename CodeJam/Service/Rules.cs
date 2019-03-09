using System;
using System.Collections.Generic;
using System.Linq;
using CodeJam.ModelDomain;
using CodeJam.ModelVm;
using CodeJam.Problems;

namespace CodeJam.Service
{
    public static class Rules
    {
        public static ScoreBoardItemVm TwoProblems10and15PointsPenalty4min(IGrouping<string, AnswerOut> userAnswers)
        {
            var item = new ScoreBoardItemVm
            {
                Username = userAnswers.Key
            };

            (item.SnowwhiteSolved, item.SnowwhiteIncorrectAttempts, item.SnowwhiteSolvingTime) =
                CheckTask(new Problem1().Id, userAnswers.ToList());

            (item.ElectionSolved, item.ElectionIncorrectAttempts, item.ElectionSolvingTime) =
                CheckTask(new Problem2().Id, userAnswers.ToList());

            if (item.SnowwhiteSolved) item.Score += 10;
            if (item.ElectionSolved) item.Score += 15;

            var lastCorrectTime = new[] { item.SnowwhiteSolvingTime, item.ElectionSolvingTime, TimeSpan.Zero }
                .Where(t => t.HasValue).Max(t => t.Value);
            item.Penalty = lastCorrectTime + TimeSpan.FromMinutes(4 * (item.SnowwhiteIncorrectAttempts + item.ElectionIncorrectAttempts));

            return item;
        }


        //todo: think how could be make it as separate rule
        public static (bool, int, TimeSpan?) CheckTask(string taskId, List<AnswerOut> answers)
        {
            answers = answers.Where(a => a.TaskId.Equals(taskId, StringComparison.OrdinalIgnoreCase))
                .OrderBy(a => a.CreatedDate).ToList();

            var solved = answers.Any(a => a.IsCorrect);
            var incorrectAttempts = answers.TakeWhile(a => !a.IsCorrect).Count();
            var timeTaken = answers.FirstOrDefault(a => a.IsCorrect)?.CreatedDate - startDate;

            return (solved, incorrectAttempts, timeTaken);
        }
    }
}
