using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;

namespace Tests.Repositories
{
    public class FakeRepository : ICartaoVirtualRepository
    {
        public void AdicionarCartaoVirtual(CartaoVirtual cartaoVirtual)
        {
            // Método intencionalmente vazio
        }

        public IEnumerable<CartaoVirtual> ListarCartaoVirtual(string email)
        {
            return new List<CartaoVirtual>();
        }
    }
}
