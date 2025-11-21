using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bernhoeft.GRT.Teste.Domain.Core.Abstractions;

namespace Bernhoeft.GRT.Teste.Domain.Core.Entities
{
    public abstract class Entity : IEntity
    {
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;

        public bool Deleted { get; set; }
    }
}
