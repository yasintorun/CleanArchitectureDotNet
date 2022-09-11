
namespace LMS.Core.Tools.Responses
{
    public interface IResponse<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
