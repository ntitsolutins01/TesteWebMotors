using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;
using MapsterMapper;

namespace Application.Subjects.Commands.Create
{
    public class CreateSubjectCommand : IRequestWrapper<SubjectDto>
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public string Quilometragem { get; set; }
        public string Observacao { get; set; }
    }

    public class CreateSubjectCommandHandler : IRequestHandlerWrapper<CreateSubjectCommand, SubjectDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateSubjectCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<SubjectDto>> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = new Subject
            {
                Marca = request.Marca,
                Modelo = request.Modelo,
                Versao = request.Versao,
                Ano = request.Ano,
                Quilometragem = request.Quilometragem,
                Observacao = request.Observacao
            };


            await _context.Subjects.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<SubjectDto>(entity));
        }
    }
}
