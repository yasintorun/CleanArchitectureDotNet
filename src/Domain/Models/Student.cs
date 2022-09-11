using LMS.Core.Domain.Models;

namespace LMS.Domain.Models
{
    public class Student : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Identity { get; private set; }

        public Student()
        {

        }

        public Student(int id, string identity, string firstname, string lastname) : this()
        {
            Id = id;
            Identity = identity;
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
