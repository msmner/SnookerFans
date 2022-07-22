namespace SnookerFans.Exceptions
{
    public class MatchNotFoundException : SnookerException, ISnookerException
    {
        public MatchNotFoundException()
           : base("Match not found")
        {
        }
    }
}
