namespace LMS.Core.Exceptions
{
    public class InternalException : Exception
    {
        public object? Details { get; set; }
        public InternalException(string message, object? details = null) : base($"error.internal {message}")
        {
            Details = details;
        }
    }
}
