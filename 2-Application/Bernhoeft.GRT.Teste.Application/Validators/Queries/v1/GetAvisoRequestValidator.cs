using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Validators.Queries.v1
{
    public class GetAvisoRequestValidator : AbstractValidator<GetAvisoRequest>
    {
        public GetAvisoRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O Id do Aviso deve ser maior que zero.");
        }
    }
}