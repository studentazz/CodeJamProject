using System.ComponentModel.DataAnnotations;

namespace CodeJam.ModelVm
{
    /// <summary>
    /// here we must have strong validation, because data is coming from outside
    /// </summary>
    public class AnswerIn
    {
        [Required(ErrorMessage = "Nickname is required")]
        [MaxLength(256, ErrorMessage = "To long nickname. Max: 256")]
        [RegularExpression(@"\w+", ErrorMessage = "Nickname can contain only letters and digits")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Problem id must be selected")]
        [MaxLength(50, ErrorMessage = "Problem id is too long: 50")]
        public string ProblemId { get; set; }

        public bool IsCorrect { get; set; }

        [Required( ErrorMessage = "No answer was given")]
        [MaxLength(20000, ErrorMessage = "Max answer length is 20k characters")]
        public string Answer { get; set; }
    }
}
