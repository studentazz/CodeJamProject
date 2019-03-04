﻿using System.Data;
using System.Data.SqlClient;
using CodeJam.ModelIn;
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
            string sql = $@"INSERT INTO dbo.CodeJam VALUES (@nickname, @taskId, @isCorrect, @answer, GETDATE())";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, answer);
            }
        }
    }
}
