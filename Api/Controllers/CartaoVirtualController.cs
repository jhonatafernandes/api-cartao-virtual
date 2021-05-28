using Domain.Commands.Inputs;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shared.Commands;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("v1/cartoes")]
    public class CartaoVirtualController : Controller
    {
        private readonly ICartaoVirtualRepository _repository;

        public CartaoVirtualController(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetService<ICartaoVirtualRepository>();
        }

        [HttpGet]
        [Route("{email}")]
        public IEnumerable<CartaoVirtual> Get(string email)
        {
            var cartoes = _repository.ListarCartaoVirtual(email);
                
            return cartoes;
        }

        
        [HttpPost]
        [Route("")]
        public ICommandResult Post([FromBody]GerarCartaoVirtualCommand command)
        {
            var handler = new GerarCartaoVirtualHandler(_repository);

            return handler.Handle(command);
        }
    }
}
