using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;
using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.EntityFramework.Domain.Interfaces;
using Bernhoeft.GRT.Core.Enums;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1
{
    public class DeleteAvisoHandler : IRequestHandler<DeleteAvisoRequest, IOperationResult<DeleteAvisoResponse>>
    {
        private readonly IServiceProvider _serviceProvider;

        private IContext _context => _serviceProvider.GetRequiredService<IContext>();
        private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();

        public DeleteAvisoHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<IOperationResult<DeleteAvisoResponse>> Handle(DeleteAvisoRequest request, CancellationToken cancellationToken)
        {
            var entity = await _avisoRepository.GetByIdAsync(request.Id, cancellationToken);

            if (entity is null || entity.Deleted)
                return OperationResult<DeleteAvisoResponse>.ReturnNotFound();

            // Soft Delete: marca como deletado ao invés de remover
            entity.Deleted = true;
            entity.DataAtualizacao = DateTime.UtcNow;

            _avisoRepository.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return OperationResult<DeleteAvisoResponse>.Return(CustomHttpStatusCode.Ok, (DeleteAvisoResponse)entity);
        }
    }
}