using AutoMapper;
using LMS.Application.Modules.Students.Queries;
using LMS.Domain.Models;

namespace LMS.Application.Modules.Students.Profiles
{
    public class StudentProfiles : Profile
    {
        public StudentProfiles()
        {
            CreateMap<Student, GetAllStudentsQueryResponse>().ReverseMap();
        }
    }
}
