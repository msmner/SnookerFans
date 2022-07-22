namespace SnookerFans.Exceptions
{
    public class AddRoleToUserException : SnookerException, ISnookerException
    {
        public AddRoleToUserException()
           : base("Error adding user role to user")
        {
        }
    }
}
