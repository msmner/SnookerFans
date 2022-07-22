namespace SnookerFans.Exceptions
{
    public class InvalidUsernameOrPasswordException : SnookerException, ISnookerException
    {
        public InvalidUsernameOrPasswordException()
           : base("Invalid username or password")
        {
        }
    }
}
