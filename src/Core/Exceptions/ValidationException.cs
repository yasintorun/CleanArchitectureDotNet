using FluentValidation.Results;

namespace LMS.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public object Failures { get; set; }
        public ValidationException(string message, object failures) : base($"error.validationFailure {message}")
        {
            Failures = failures;
        }
    }
}
