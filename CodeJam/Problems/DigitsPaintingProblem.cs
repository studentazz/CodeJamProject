namespace CodeJam.Problems
{
    public class DigitsPaintingProblem : IProblem
    {
        public string TaskId => "dazymas";

        public string Input => @"5
5
101
102
5003
261060
25665";

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
