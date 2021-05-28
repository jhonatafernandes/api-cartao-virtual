using Domain.Commands.Inputs;
using Domain.Commands.Results;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Shared.Commands;
using System;

namespace Domain.Handlers
{
    public class GerarCartaoVirtualHandler{
        private readonly ICartaoVirtualRepository _repository;

        public GerarCartaoVirtualHandler(ICartaoVirtualRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(GerarCartaoVirtualCommand command){
            //Validar Command
            command.Validar();

            if (command.Invalid)
                return new CommandResult(false, "Email Inválido", command.Notifications);

            //Gerar número de cartão aleatório
            var numeroCartao = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                var random = new Random();
                var blocoCartao = $"{random.Next(1000, 9999)}";
                numeroCartao = $"{numeroCartao + blocoCartao}";
            }

            //Criar entidade e salvar no banco
            var cartaoVirtual = new CartaoVirtual(command.Email, numeroCartao, DateTime.Now);
            try
            {
                _repository.AdicionarCartaoVirtual(cartaoVirtual);
            }
            catch (Exception e)
            {
                return new CommandResult(false, "Erro ao salvar os dados", e.Message);
            }

            //Crar command result e retornar
            return new CommandResult(true, "Requisição Realizada com Sucesso", new { command.Email, numeroCartao });
        }
    }
}