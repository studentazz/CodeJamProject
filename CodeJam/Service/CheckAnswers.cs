using System;

namespace CodeJam.Service
{
    public class CheckAnswers
    {

        public bool IsAnswerCorrect(string taskId, string answer)
        {
            string[] lines = answer.Split(Environment.NewLine);

            switch (taskId)
            {
                case "1":
                    break;
                case "2":
                    break;
                default:
                    return false;
            }

            return false;
        }
    }
}
