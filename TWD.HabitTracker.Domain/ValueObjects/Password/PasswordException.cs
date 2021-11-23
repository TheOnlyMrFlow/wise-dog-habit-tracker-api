namespace TWD.HabitTracker.Domain.ValueObjects.Password
{
    public class PasswordException : Exception
    {
        private const string PublicMessage = "Password is not compliant.";

        public PasswordException(string message = PublicMessage) : base(message) { }

        public PasswordException(Exception innerException, string message = PublicMessage) : base(message, innerException) { }
    }
}