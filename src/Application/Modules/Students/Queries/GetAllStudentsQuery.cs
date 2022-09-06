using AutoMapper;
using LMS.Application.Abstractions.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LMS.Application.Modules.Students.Queries
{
    public record GetAllStudentsQuery : IRequest<List<GetAllStudentsQueryResponse>>;

    public record GetAllStudentsQueryResponse(int Id, string FirstName, string LastName, string Identity);

    public record GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<GetAllStudentsQueryResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public GetAllStudentsQueryHandler(ILogger<GetAllStudentsQueryHandler> logger, IMapper mapper, IStudentRepository studentRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<List<GetAllStudentsQueryResponse>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.GetListAysnc();

            return students.ToList().ConvertAll(x => _mapper.Map<GetAllStudentsQueryResponse>(x));
        }
    }
}
