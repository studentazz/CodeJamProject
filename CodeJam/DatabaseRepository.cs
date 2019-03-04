using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CodeJam.ModelIn;
using Dapper;

namespace CodeJam
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
            string sql = $@"INSERT INTO dbo.CodeJam VALUES (@nickname, @taskId, @isCorrect, @answer)";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sql, answer);
            }
        }
    }
}
