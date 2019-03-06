namespace CodeJam.Problems
{
    public class DigitsPaintingProblem : IProblem
    {
        public string TaskId => "dazymas";

        public string Input =>
@"Testas #1: 5
Testas #2: 5
Testas #3: 101
Testas #4: 102
Testas #5: 5003
Testas #6: 261060
Testas #7: 25665";

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
