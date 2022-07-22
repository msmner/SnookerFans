namespace SnookerFans.Exceptions
{
    public interface ISnookerException
    {
        string Message { get; }

        string Service { get; }

        public string? StackTrace { get; set; }
    }
}
