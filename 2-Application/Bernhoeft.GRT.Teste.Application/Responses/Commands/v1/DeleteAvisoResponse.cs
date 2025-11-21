using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;

namespace Bernhoeft.GRT.Teste.Application.Responses.Commands.v1
{
    public class DeleteAvisoResponse
    {
        public int Id { get; set; }

        public static implicit operator DeleteAvisoResponse(AvisoEntity entity) => new()
        {
            Id = entity.Id,
        };
    }
}