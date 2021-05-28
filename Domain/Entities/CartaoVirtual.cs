using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CartaoVirtual{
        public CartaoVirtual(string email, string numeroCartao, DateTime dataCriacao)
        {
            Email = email;
            NumeroCartao = numeroCartao;
            DataCriacao = dataCriacao;
        }

        [Key]
        public int Id { get; private set; }
        public string Email { get; private set; }

        [MaxLength(16, ErrorMessage = "Este campo deve conter no máximo 16 caracteres")]
        public string NumeroCartao { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}
