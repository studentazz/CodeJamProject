using System;

namespace CodeJam.Service
{
    public class CheckAnswers
    {

        public bool IsAnswerCorrect(string taskId, string answer)
        {
            answer = answer.Trim(new char[] { '\r', '\n', ' '  });
            switch (taskId)
            {
                case "snieguole":
                    break;
                case "dazymas":
                    string correct = 
@"5
5
101
102
5003
261060
25665";
                    if (correct == answer)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }

            return false;
        }
    }
}
