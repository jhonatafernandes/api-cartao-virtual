using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class CartaoVirtualRepository : ICartaoVirtualRepository
    {
        private readonly DataContext _context;
        public CartaoVirtualRepository(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetService<DataContext>();
        }

        public void AdicionarCartaoVirtual(CartaoVirtual cartaoVirtual)
        {
            _context.Cartoes.Add(cartaoVirtual);
            _context.SaveChanges();
        }

        public IEnumerable<CartaoVirtual> ListarCartaoVirtual(string email)
        {
            return _context.Cartoes.AsNoTracking().Where(it => it.Email == email).OrderBy(x => x.DataCriacao).ToList();
        }
    }
}
