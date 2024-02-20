namespace AppMobileBackEnd.Exceptions
{
    public class UserFriendlyExceptions : Exception
    {
        public UserFriendlyExceptions(string message)
            : base(message) { }
    }
}
