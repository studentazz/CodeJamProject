using CodeJam.ModelIn;
using CodeJam.Repository;
using CodeJam.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeJam.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseRepository _databaseRepository;

        public IndexModel(DatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public void OnGet()
        {
            
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost(AnswerIn answerIn)
        {
            if (ModelState.IsValid)
            {
                var checker = new CheckAnswers();
                answerIn.IsCorrect = checker.IsAnswerCorrect(answerIn.TaskId, answerIn.Answer);
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
            return Page();
        }
    }
}
