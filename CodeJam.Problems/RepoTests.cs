using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeJam.ModelVm;
using CodeJam.Repository;
using NUnit.Framework;

namespace CodeJam.Interfaces
{
    [TestFixture]
    public class RepoTests
    {
        private const string ConnStr = "Server=tcp:goblindb.database.windows.net,1433;Initial Catalog=datavault;" +
                                       "Persist Security Info=False;User ID=goblin;Password=xerofKK33;" +
                                       "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        [Test]
        public async Task GetResultsTest()
        {
            var repo = new DatabaseRepository(ConnStr);
            var res = repo.GetResults(DateTimeOffset.UtcNow.AddMinutes(-20).ToUnixTimeSeconds(),
                new DateTimeOffset(2019, 3, 7, 12, 11, 0, TimeSpan.Zero).ToUnixTimeSeconds());
        }

        [Test]
        public async Task InputTest()
        {
            var repo = new DatabaseRepository(ConnStr);
            repo.SaveAnswer(new AnswerIn {Nickname = "Yo", IsCorrect = true, Answer = "4", ProblemId = "snieguole"});
        }
    }
}
