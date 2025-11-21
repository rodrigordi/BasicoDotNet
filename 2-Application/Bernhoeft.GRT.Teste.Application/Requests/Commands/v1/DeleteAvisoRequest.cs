using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1
{
    public class DeleteAvisoRequest : IRequest<IOperationResult<DeleteAvisoResponse>>
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}