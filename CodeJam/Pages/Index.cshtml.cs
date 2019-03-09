using System;
using CodeJam.ModelVm;
using CodeJam.Repository;
using CodeJam.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeJam.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseRepository _databaseRepository;

        public ProblemContainer ProblemContainer { get; set; }


        public IndexModel(DatabaseRepository databaseRepository, ProblemContainer problemContainer)
        {
            _databaseRepository = databaseRepository;
            ProblemContainer = problemContainer;

        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost(AnswerIn answerIn)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var container = new ProblemContainer();
                    answerIn.IsCorrect = container.IsProblemSolved(answerIn.ProblemId, answerIn.Answer);
                    _databaseRepository.SaveAnswer(answerIn);
                    if (answerIn.IsCorrect)
                    {
                        return RedirectToPage(@"Correct");
                    }
                    else
                    {
                        return RedirectToPage(@"Incorrect");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("error", ex.Message);
                }
            }
            return Page();
        }
    }
}
