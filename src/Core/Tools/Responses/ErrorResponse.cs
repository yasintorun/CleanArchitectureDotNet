namespace LMS.Core.Tools.Responses
{
    public class ErrorResponse : IResponse<Object>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public Object? Data { get; set; }
        public object? Detail { get; set; }

        public ErrorResponse()
        {
            Data = null;
            Success = false;
            StatusCode = 400;
            Message = "error.occured";
            Detail = null;
        }
        public ErrorResponse(int statusCode, string message) : this()
        {
            StatusCode = statusCode;
            Message = message;
        }

        public ErrorResponse(int statusCode, string message, object? detail) : this(statusCode, message)
        {
            Detail = detail;
        }
    }
}
