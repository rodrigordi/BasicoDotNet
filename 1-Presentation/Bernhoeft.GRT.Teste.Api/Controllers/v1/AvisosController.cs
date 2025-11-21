using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;

namespace Bernhoeft.GRT.Teste.Api.Controllers.v1
{
    /// <response code="401">Não Autenticado.</response>
    /// <response code="403">Não Autorizado.</response>
    /// <response code="500">Erro Interno no Servidor.</response>
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = null)]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = null)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = null)]
    public class AvisosController : RestApiController
    {
        /// <summary>
        /// Retorna um Aviso por ID.
        /// </summary>
        /// <param name="request">Request com o ID do Aviso.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Aviso.</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="400">Dados Inválidos.</response>
        /// <response code="404">Aviso Não Encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAvisoResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<object> GetAviso([FromRoute] GetAvisoRequest request, CancellationToken cancellationToken)
            => await Mediator.Send(request, cancellationToken);



        /// <summary>
        /// Retorna Todos os Avisos Cadastrados para Tela de Edição.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Lista com Todos os Avisos.</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="204">Sem Avisos.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDocumentationRestResult<IEnumerable<GetAvisosResponse>>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<object> GetAvisos(CancellationToken cancellationToken)
            => await Mediator.Send(new GetAvisosRequest(), cancellationToken);



        /// <summary>
        /// Cria um novo Aviso.
        /// </summary>
        /// <param name="request">Dados do Aviso a ser criado.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Aviso criado.</returns>
        /// <response code="201">Aviso criado com sucesso.</response>
        /// <response code="400">Dados Inválidos.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateAvisoResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<object> CreateAviso([FromBody] CreateAvisoRequest request, CancellationToken cancellationToken)
            => await Mediator.Send(request, cancellationToken);



        /// <summary>
        /// Atualiza a Mensagem de um Aviso existente.
        /// </summary>
        /// <param name="id">ID do Aviso.</param>
        /// <param name="request">Dados para atualização.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Aviso atualizado.</returns>
        /// <response code="200">Aviso atualizado com sucesso.</response>
        /// <response code="400">Dados Inválidos.</response>
        /// <response code="404">Aviso Não Encontrado.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateAvisoMensagemResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<object> UpdateAvisoMensagem([FromRoute] int id, [FromBody] UpdateAvisoMensagemRequest request, CancellationToken cancellationToken)
        {
            request.Id = id; // Garante que o Id da rota sobrescreve o Id do body (se vier)
            return await Mediator.Send(request, cancellationToken);
        }


        /// <summary>
        /// Remove um Aviso (Soft Delete).
        /// </summary>
        /// <param name="request">Request com o ID do Aviso.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Sem conteúdo.</returns>
        /// <response code="204">Aviso removido com sucesso.</response>
        /// <response code="400">Dados Inválidos.</response>
        /// <response code="404">Aviso Não Encontrado.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<object> DeleteAviso([FromRoute] DeleteAvisoRequest request, CancellationToken cancellationToken)
            => await Mediator.Send(request, cancellationToken);
    }
}