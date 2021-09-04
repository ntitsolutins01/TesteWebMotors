using FluentValidation;

namespace Application.WebmotorsSwagger.Queries.GetWebMotorsQuery
{
    public class GetWebMotorsValidator : AbstractValidator<GetWebMotorsQuery>
    {
        public GetWebMotorsValidator()
        {
            //RuleFor(x=>x.Id)
            //    .NotNull()
            //    .NotEmpty().WithMessage("Id is required.");
            
            //RuleFor(x=>x.MakeID)
            //    .NotNull()
            //    .NotEmpty().WithMessage("MakeID is required.");
            
            //RuleFor(x=>x.ModelID)
            //    .NotNull()
            //    .NotEmpty().WithMessage("ModelID is required.");
            
            //RuleFor(x=>x.Page)
            //    .NotNull()
            //    .NotEmpty().WithMessage("Page is required.");
        }
    }
}