namespace CodeJam.Problems
{
    public interface IProblem
    {
        string TaskId { get; }
        string Input { get; }
        bool CheckOutput(string output);
    }
}
