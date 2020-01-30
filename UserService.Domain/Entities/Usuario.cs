using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Domain.Entities
{
    public class Usuario : Entity
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
        public int? Cnh { get; set; }
        public string Cep { get; set; }
        public string DeviceToken { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
        public Usuario(int id, string nome, string email, string senha, int idProfile, string endereco, string cidade,
        string numeroResidencia, string telefone, string cep, int? cnh, string bairro, string deviceToken) : base(id)
        {
            this.Nome = nome;
            this.Senha = senha;
            this.DeviceToken = deviceToken;
            this.Email = email;
            this.IdProfile = idProfile;
            this.Endereco = endereco;
            this.Cidade = cidade;
            this.NumeroResidencia = numeroResidencia;
            this.Bairro = bairro;
            this.Telefone = telefone;
            this.Cep = cep;
            this.Cnh = cnh;
        }
    }
}
