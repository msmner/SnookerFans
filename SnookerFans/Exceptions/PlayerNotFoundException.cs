namespace SnookerFans.Exceptions
{
    public class PlayerNotFoundException : SnookerException, ISnookerException
    {
        public PlayerNotFoundException()
           : base("Player not found")
        {
        }
    }
}
