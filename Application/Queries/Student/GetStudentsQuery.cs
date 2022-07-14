using CleanArchitecture.Application.Abstractions.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Queries
{
    public record GetStudentsQuery() : IRequest<List<GetStudentsQueryResponse>>;
    public record GetStudentsQueryResponse(int Id, string Name, string StudentNumber);
    public record GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<GetStudentsQueryResponse>>
    {
        private readonly ILogger<GetStudentsQueryHandler> _logger;
        private readonly IStudentService _studentService;

        public GetStudentsQueryHandler(ILogger<GetStudentsQueryHandler> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        public async Task<List<GetStudentsQueryResponse>> Handle(GetStudentsQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"GetStudentsQueryHandler process started with query: {query}");

            var students = await _studentService.GetStudentsAsync();
            var response = students.ConvertAll(x => new GetStudentsQueryResponse(x.Id, x.Name, x.StudentNumber));
            
            _logger.LogInformation($"GetStudentsQueryHandler process finished with response: {response}");
            return response;
        }
    }
}
