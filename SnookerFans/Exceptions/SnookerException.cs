namespace SnookerFans.Exceptions
{
    public class SnookerException : Exception, ISnookerException
    {
        public virtual string Service { get; set; } = "SnookerFansService";

        public new string? StackTrace { get; set; } = null!;

        public SnookerException()
        { }

        public SnookerException(string message)
            : base(message)
        {
        }
    }
}
