using LMS.Core.Domain.Models;

namespace LMS.WebAPI.Requests.Defaults
{
    public record DefaultPaginateRequest (int pageNum, int pageSize)
    {
        public PaginateRequest To()
        {
            return new PaginateRequest(pageNum, pageSize);
        }
    }
}
