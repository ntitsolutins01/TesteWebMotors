using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Subjects.Queries.GetSubjectById
{
    public class GetSubjectByIdQuery : IRequestWrapper<SubjectDto>
    {
        public int Id { get; set; }
    }

    public class GetCityByIdQueryHandler : IRequestHandlerWrapper<GetSubjectByIdQuery, SubjectDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCityByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<SubjectDto>> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            var subject = await _context.Subjects
                .Where(x => x.Id == request.Id)
                .ProjectToType<SubjectDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return subject != null ? ServiceResult.Success(subject) : ServiceResult.Failed<SubjectDto>(ServiceError.NotFount);
        }
    }
}
