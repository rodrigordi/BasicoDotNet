using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bernhoeft.GRT.Teste.Domain.Core.Abstractions
{
    public interface IEntity
    {
        DateTime DataCriacao { get; }
        DateTime DataAtualizacao { get; }
        bool Deleted { get; }
    }
}
