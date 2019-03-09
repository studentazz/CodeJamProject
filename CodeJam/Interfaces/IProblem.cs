namespace CodeJam.Problems
{
    public interface IProblem
    {
        /// <summary>
        /// Problem Id
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Given Input string for contest participants
        /// </summary>
        string Input { get; }

        /// <summary>
        /// Checks if problem was solved correctly
        /// </summary>
        /// <param name="output">Output string, which was submited by participants</param>
        /// <returns></returns>
        bool IsSoved(string output);
    }
}
