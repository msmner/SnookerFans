namespace SnookerFans.Exceptions
{
    public class ErrorCreatingUser : SnookerException, ISnookerException
    {
        public ErrorCreatingUser()
           : base("Got errors creating the user. Check console for more information")
        {
        }
    }
}
