using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeJam.ModelIn;
using CodeJam.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeJam.Pages
{
    public class RezultatuLenteleModel : PageModel
    {
        private readonly DatabaseRepository _databaseRepository;

        public ScoreBoardItem[] Participants { get; set; }

        public RezultatuLenteleModel(DatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
            Participants = new ScoreBoardItem[] { new ScoreBoardItem {
                Username = "Saulius",
                Score = 15,
                Penalty = new TimeSpan(0, 25, 6),
                SnowwhiteSolved = true,
                SnowwhiteSolvingTime = new TimeSpan(0, 12, 30),
                SnowwhiteIncorrectAttempts = 1,
                ElectionSolved = false,
                ElectionIncorrectAttempts = 3
            },
            new ScoreBoardItem {
                Username = "Saulius2",
                Score = 15,
                Penalty = new TimeSpan(0, 25, 6),
                SnowwhiteSolved = true,
                SnowwhiteSolvingTime = new TimeSpan(0, 12, 30),
                SnowwhiteIncorrectAttempts = 1,
                ElectionSolved = false,
                ElectionIncorrectAttempts = 3
            },
            new ScoreBoardItem {
                Username = "Saulius3",
                Score = 15,
                Penalty = new TimeSpan(0, 25, 6),
                SnowwhiteSolved = true,
                SnowwhiteSolvingTime = new TimeSpan(0, 12, 30),
                SnowwhiteIncorrectAttempts = 1,
                ElectionSolved = false,
                ElectionIncorrectAttempts = 3
            }};
        }

        public void OnGet(DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            Participants = _databaseRepository.GetResults(startDate?.ToUnixTimeSeconds() ?? DateTimeOffset.Now.ToUnixTimeSeconds(),
                endDate?.ToUnixTimeSeconds() ?? DateTimeOffset.MaxValue.ToUnixTimeSeconds());
        }
    }
}