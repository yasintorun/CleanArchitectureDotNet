using LMS.Core.Domain.Models;

namespace LMS.Domain.Models
{
    public class Student : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identity { get; set; }
    }
}
