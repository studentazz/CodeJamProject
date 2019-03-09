using System;
using CodeJam.ModelVm;
using CodeJam.Repository;
using CodeJam.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CodeJam.Pages
{
    public class ResultTableModel : PageModel
    {
        private readonly DatabaseRepository _databaseRepository;
        private readonly IConfiguration _config;

        public ScoreBoardItemVm[] Participants { get; set; } = new ScoreBoardItemVm[] {  };

        public ProblemContainer ProblemContainer { get; set; }

        public ResultTableModel(DatabaseRepository databaseRepository, ProblemContainer problemContainer, IConfiguration config)
        {
            _databaseRepository = databaseRepository;
            _config = config;
            ProblemContainer = problemContainer;
        }

        public void OnGet(string miniPassword, DateTime? startDate, DateTime? endDate)
        {
            if (!_config.GetValue<bool>("UseResultPassword") || miniPassword == _config.GetValue<string>("ResultTablePassword"))
            {
                Participants = _databaseRepository.GetResults(startDate ?? DateTime.MinValue, endDate ?? DateTime.MaxValue);
            }
        }
    }
}