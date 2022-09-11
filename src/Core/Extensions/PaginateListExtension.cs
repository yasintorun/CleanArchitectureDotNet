using LMS.Core.Domain.Models;

namespace LMS.Core.Extensions
{
    public static class PaginateListExtension
    {
        public static Paginate<T> ToPaginate<T>(this IList<T> list, int pageNum, int pageSize)
        {
            IList<T> items = list.Skip(pageNum * pageSize).Take(pageSize).ToList();

            return new Paginate<T>(pageNum, pageSize, list.Count, items);
        }
    }
}
