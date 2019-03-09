using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CodeJam.ModelVm;
using CodeJam.Interfaces;
using Dapper;
using CodeJam.ModelDomain;
using CodeJam.Service;

namespace CodeJam.Repository
{
    public class DatabaseRepository
    {
        private readonly string _connectionString;

        #region TABLE SQL
        private readonly string tableSQL =
            @"
                SET ANSI_NULLS ON
                GO

                SET QUOTED_IDENTIFIER ON
                GO

                CREATE TABLE [dbo].[CodeJam](
	                [_id] [int] IDENTITY(1,1) NOT NULL,
	                [_status] [tinyint] NOT NULL,
	                [nickname] [nvarchar](256) NOT NULL,
	                [taskId] [nvarchar](50) NOT NULL,
	                [isCorrect] [bit] NOT NULL,
	                [answer] [nvarchar](max) NULL,
	                [createdDate] [datetime] NOT NULL,
                 CONSTRAINT [PK_CodeJam] PRIMARY KEY CLUSTERED 
                (
	                [_id] ASC
                )WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
                ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                GO

                ALTER TABLE [dbo].[CodeJam] ADD  CONSTRAINT [DF_CodeJam__status]  DEFAULT ((1)) FOR [_status]
                GO

                ALTER TABLE [dbo].[CodeJam] ADD  CONSTRAINT [DF_CodeJam_createdDate]  DEFAULT (getdate()) FOR [createdDate]
                GO
            "; 
        #endregion

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

        public ScoreBoardItemVm[] GetResults(DateTime startDate, DateTime endDate)
        {
            var problemIds = new ProblemContainer().Problems.Select(p => p.Id);
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var answers = db.Query<AnswerOut>("SELECT * FROM dbo.CodeJam WHERE [taskId] IN @problemIds", new { problemIds }).ToArray();

                return answers
                    .Where(a => a.CreatedDate > startDate)
                    .Where(a => a.CreatedDate < endDate)
                    .GroupBy(a => a.Nickname)
                    .Select(Map)
                    .OrderByDescending(i => i.Score)
                    .ThenBy(i => i.Penalty)
                    .ToArray();
            }

            ScoreBoardItemVm Map(IGrouping<string, AnswerOut> userAnswers)
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
                var timeTaken = answers.FirstOrDefault(a => a.IsCorrect)?.CreatedDate - startDate;

                return (solved, incorrectAttempts, timeTaken);
            }
        }
    }
}
