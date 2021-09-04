using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Subjects.Queries.GetSubjects
{
    public class GetAllSubjectsQuery : IRequestWrapper<List<SubjectDto>>
    {

    }

    public class GetCitiesQueryHandler : IRequestHandlerWrapper<GetAllSubjectsQuery, List<SubjectDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCitiesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<SubjectDto>>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
        {
            List<SubjectDto> list = await _context.Subjects
                .ProjectToType<SubjectDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<SubjectDto>>(ServiceError.NotFount);
        }
    }
}
