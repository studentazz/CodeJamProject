using System.ComponentModel.DataAnnotations;

namespace CodeJam.ModelIn
{
    public class AnswerIn
    {
        [Required(ErrorMessage = "reikalingas nickname!")]
        [MaxLength(256, ErrorMessage = "Per ilgas nickname: 256")]
        [RegularExpression(@"\w+", ErrorMessage = "vardas gali buti tik raides")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "reikalingas uzduoties id")]
        [MaxLength(50, ErrorMessage = "Per ilgas taskid: 50")]
        public string TaskId { get; set; }

        public bool IsCorrect { get; set; }

        [Required( ErrorMessage = "nera atsakymo")]
        [MaxLength(20000, ErrorMessage = "per ilgas atsakymas: 20000")]
        public string Answer { get; set; }
    }
}
