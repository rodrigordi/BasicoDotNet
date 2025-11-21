using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bernhoeft.GRT.Teste.Application.Requests.Queries.v1
{
    public class GetAvisoRequest : IRequest<IOperationResult<GetAvisoResponse>>
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}