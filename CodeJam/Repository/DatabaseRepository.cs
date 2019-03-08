using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CodeJam.ModelIn;
using CodeJam.Problems;
using Dapper;

namespace CodeJam.Repository
{
    public class DatabaseRepository
    {
        private readonly string _connectionString;

        public DatabaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SaveAnswer(AnswerIn answer)
        {
            string sql = $@"INSERT INTO dbo.CodeJam VALUES (1, @nickname, @taskId, @isCorrect, @answer, GETDATE())";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, answer);
            }
        }

        public ScoreBoardItem[] GetResults(long utcSecondsStart, long utcSecondsEnd)
        {
            var startDate = DateTimeOffset.FromUnixTimeSeconds(utcSecondsStart);
            var endDate = DateTimeOffset.FromUnixTimeSeconds(utcSecondsEnd);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var answers = db.Query<AnswerOut>("SELECT * FROM dbo.CodeJam").ToArray();

                return answers
                    .Where(a => a.SubmitDate > startDate)
                    .Where(a => a.SubmitDate < endDate)
                    .GroupBy(a => a.Nickname)
                    .Select(Map)
                    .OrderByDescending(i => i.Score)
                    .ThenBy(i => i.Penalty)
                    .ToArray();
            }

            ScoreBoardItem Map(IGrouping<string, AnswerOut> userAnswers)
            {
                var item = new ScoreBoardItem
                {
                    Username = userAnswers.Key
                };

                (item.SnowwhiteSolved, item.SnowwhiteIncorrectAttempts, item.SnowwhiteSolvingTime) =
                    CheckTask(new SnowWhiteProblem().TaskId, userAnswers.ToList());

                (item.ElectionSolved, item.ElectionIncorrectAttempts, item.ElectionSolvingTime) =
                    CheckTask(new DigitsPaintingProblem().TaskId, userAnswers.ToList());

                if (item.SnowwhiteSolved) item.Score += 10;
                if (item.ElectionSolved) item.Score += 15;

                var lastCorrectTime = new[] {item.SnowwhiteSolvingTime, item.ElectionSolvingTime, TimeSpan.Zero}
                    .Where(t => t.HasValue).Max(t => t.Value);
                item.Penalty = lastCorrectTime + TimeSpan.FromMinutes(4 * (item.SnowwhiteIncorrectAttempts + item.ElectionIncorrectAttempts));

                return item;
            }

            (bool, int, TimeSpan?) CheckTask(string taskId, List<AnswerOut> answers)
            {
                answers = answers.Where(a => a.TaskId.Equals(taskId, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(a => a.CreatedDate).ToList();

                var solved = answers.Any(a => a.IsCorrect);
                var incorrectAttempts = answers.TakeWhile(a => !a.IsCorrect).Count();
                var timeTaken = answers.FirstOrDefault(a => a.IsCorrect)?.SubmitDate - startDate;

                return (solved, incorrectAttempts, timeTaken);
            }
        }
    }
}
