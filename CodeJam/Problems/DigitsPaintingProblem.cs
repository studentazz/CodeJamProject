namespace CodeJam.Problems
{
    public class DigitsPaintingProblem : IProblem
    {
        public string TaskId => "rinkimai";

        public string Input =>
@"Testas #1: 128 NE
Testas #2: 5 TAIP
Testas #3: 5 TAIP
Testas #4: 101 TAIP
Testas #5: 102 TAIP
Testas #6: 5003 TAIP
Testas #7: 261060 TAIP
Testas #8: 25665 TAIP";

        public bool CheckOutput(string answer)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                return false;
            }

            answer = answer.Trim(new char[] { '\r', '\n', ' ' });
            if (Input == answer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
