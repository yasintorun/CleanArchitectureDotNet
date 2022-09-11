using LMS.Core.Domain.Abstractions;

namespace LMS.Core.Domain.Models
{
    public record PaginateRequest(int PageNum, int PageSize) : IPaginateRequest;
}