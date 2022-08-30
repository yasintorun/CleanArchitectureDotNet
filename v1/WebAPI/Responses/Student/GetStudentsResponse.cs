using CleanArchitecture.Application.Queries;

namespace CleanArchitecture.Api.Responses
{
    public record GetStudentsResponse(int Id, string Name, string StudentNumber)
    {
        public static GetStudentsResponse From(GetStudentsQueryResponse response)
        {
            return new(response.Id, response.Name, response.StudentNumber);
        }
    }
}
