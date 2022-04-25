using FluentValidation;

namespace Application.Domain.Libros.Command.CreateLibro
{
    public class CreateLibroValidator : AbstractValidator<CreateLibroCommand>
    {
        public CreateLibroValidator()
        {
            RuleFor(v => v.Titulo)
                .MaximumLength(45)
                .NotEmpty().WithMessage("Tiulo es requerido");
            RuleFor(v => v.Sinopsis)
                .NotEmpty().WithMessage("Sinopsis es requerido");
            RuleFor(v => v.N_Paginas)
                .MaximumLength(45)
                .NotEmpty().WithMessage("N_Paginas es requerido");
        }
    }
}
