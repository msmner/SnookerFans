namespace SnookerFans.Exceptions
{
    public class UsernameAlreadyExistsException : SnookerException, ISnookerException
    {
        public UsernameAlreadyExistsException()
           : base("Username is already taken")
        {
        }
    }
}
