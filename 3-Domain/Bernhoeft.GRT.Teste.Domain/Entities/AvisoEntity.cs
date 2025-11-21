using System.Diagnostics.Tracing;
using Bernhoeft.GRT.Teste.Domain.Core.Entities;

namespace Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities
{
    public partial class AvisoEntity : Entity
    {
        public int Id { get; private set; }
        public bool Ativo { get; set; } = true;
        public string Titulo { get; set; }
        public string Mensagem { get; set; }

       
    }
}