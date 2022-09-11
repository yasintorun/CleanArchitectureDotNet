using AutoMapper;
using LMS.Application.Abstractions.Services;
using LMS.Core.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LMS.Application.Modules.Students.Queries
{
    public record GetAllStudentsQuery(PaginateRequest PaginateRequest) : IRequest<Paginate<GetAllStudentsQueryResponse>>;

    public record GetAllStudentsQueryResponse(int Id, string FirstName, string LastName, string Identity);

    public record GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, Paginate<GetAllStudentsQueryResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        public GetAllStudentsQueryHandler(ILogger<GetAllStudentsQueryHandler> logger, IMapper mapper, IStudentService studentService)
        {
            _logger = logger;
            _mapper = mapper;
            _studentService = studentService;
        }

        public async Task<Paginate<GetAllStudentsQueryResponse>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetListAsync(null, request.PaginateRequest);

            return students.ConvertItems(x => _mapper.Map<GetAllStudentsQueryResponse>(x));
        }
    }
}
