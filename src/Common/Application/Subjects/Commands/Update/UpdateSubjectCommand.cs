using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;
using MapsterMapper;

namespace Application.Subjects.Commands.Update
{
    public class UpdateSubjectCommand : IRequestWrapper<SubjectDto>
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public string Quilometragem { get; set; }
        public string Observacao { get; set; }
    }

    public class UpdateCityCommandHandler : IRequestHandlerWrapper<UpdateSubjectCommand, SubjectDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCityCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<SubjectDto>> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Subjects.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Subject), request.Id);
            }
            entity.Marca = request.Marca;
            entity.Modelo = request.Modelo;
            entity.Versao = request.Versao;
            entity.Ano = request.Ano;
            entity.Quilometragem = request.Quilometragem;
            entity.Observacao = request.Observacao;

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<SubjectDto>(entity));
        }
    }
}
