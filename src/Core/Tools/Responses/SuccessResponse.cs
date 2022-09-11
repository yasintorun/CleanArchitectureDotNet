namespace LMS.Core.Tools.Responses
{
    public class SuccessResponse : IResponse<Object>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Object? Data { get; set; }

        public SuccessResponse()
        {
            Success = true;
            StatusCode = 200;
            Message = "success";
            Data = null;
        }

        public SuccessResponse(int statusCode, string message) : this()
        {
            StatusCode = statusCode;
            Message = message;
        }

        public SuccessResponse(int statusCode, string message, object? data) : this(statusCode, message)
        {
            Data = data;
        }
    }
}
