using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface ICartaoVirtualRepository
    {
        void AdicionarCartaoVirtual(CartaoVirtual cartaoVirtual);
        IEnumerable<CartaoVirtual> ListarCartaoVirtual(string email);
    }
}
