using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Subjects.Commands.Update
{
    public class UpdateSubjectCommandValidator : AbstractValidator<UpdateSubjectCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateSubjectCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Marca)
                .MaximumLength(45).WithMessage("Make must not exceed 100 characters.")
                .MustAsync(BeUniqueMake).WithMessage("The specified make already exists.")
                .NotEmpty().WithMessage("Make is required.");
            RuleFor(v => v.Modelo)
                .MaximumLength(45).WithMessage("Model must not exceed 100 characters.")
                .MustAsync(BeUniqueModel).WithMessage("The specified model already exists.")
                .NotEmpty().WithMessage("Model is required.");
            RuleFor(v => v.Versao)
                .MaximumLength(45).WithMessage("Version must not exceed 100 characters.")
                .MustAsync(BeUniqueVersion).WithMessage("The specified version already exists.")
                .NotEmpty().WithMessage("Version is required.");
            RuleFor(v => v.Ano)
                .NotEmpty().WithMessage("Year is required.");
            RuleFor(v => v.Quilometragem)
                .NotEmpty().WithMessage("KM is required.");
            RuleFor(v => v.Observacao)
                .NotEmpty().WithMessage("OBS is required.");

            RuleFor(v => v.Id).NotNull();
        }

        private async Task<bool> BeUniqueMake(string name, CancellationToken cancellationToken)
        {
            //TODO: Control by uppercase and CultureInfo
            return await _context.Subjects.AllAsync(x => x.Marca != name, cancellationToken);
        }
        private async Task<bool> BeUniqueModel(string name, CancellationToken cancellationToken)
        {
            //TODO: Control by uppercase and CultureInfo
            return await _context.Subjects.AllAsync(x => x.Modelo != name, cancellationToken);
        }
        private async Task<bool> BeUniqueVersion(string name, CancellationToken cancellationToken)
        {
            //TODO: Control by uppercase and CultureInfo
            return await _context.Subjects.AllAsync(x => x.Versao != name, cancellationToken);
        }
    }
}
