using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Validators.Commands.v1
{
    public class UpdateAvisoMensagemRequestValidator : AbstractValidator<UpdateAvisoMensagemRequest>
    {
        public UpdateAvisoMensagemRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O Id do Aviso deve ser maior que zero.");

            RuleFor(x => x.Mensagem)
                .NotEmpty()
                .WithMessage("A Mensagem é obrigatória.")
                .MaximumLength(2147483647)
                .WithMessage("A Mensagem excedeu o tamanho máximo permitido.");
        }
    }
}