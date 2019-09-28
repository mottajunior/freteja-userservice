using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Domain.DTO
{
    public class ClienteDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdProfile { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string NumeroResidencia { get; set; }
        public string Bairro { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
    }
}
