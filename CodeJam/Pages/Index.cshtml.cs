using CodeJam.ModelIn;
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
                //cia serviciuskas patirinti atsakymus
                _databaseRepository.SaveAnswer(answerIn);
            }
            return Page();
        }
    }
}
