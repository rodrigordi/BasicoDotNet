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
    public class UpdateAvisoMensagemHandler : IRequestHandler<UpdateAvisoMensagemRequest, IOperationResult<UpdateAvisoMensagemResponse>>
    {
        private readonly IServiceProvider _serviceProvider;

        private IContext _context => _serviceProvider.GetRequiredService<IContext>();
        private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();

        public UpdateAvisoMensagemHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<IOperationResult<UpdateAvisoMensagemResponse>> Handle(UpdateAvisoMensagemRequest request, CancellationToken cancellationToken)
        {
            var entity = await _avisoRepository.GetByIdAsync(request.Id, cancellationToken);
            
            if (entity is default(AvisoEntity))
                return OperationResult<UpdateAvisoMensagemResponse>.ReturnNotFound();

            // Atualiza APENAS a mensagem
            entity.Mensagem = request.Mensagem;
            entity.DataAtualizacao = DateTime.UtcNow;

            _avisoRepository.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return OperationResult<UpdateAvisoMensagemResponse>.ReturnOk((UpdateAvisoMensagemResponse)entity);
        }
    }
}