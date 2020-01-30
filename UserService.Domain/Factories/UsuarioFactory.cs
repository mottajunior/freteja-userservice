using System;
using System.Collections.Generic;
using System.Text;
using UserService.Domain.DTO;
using UserService.Domain.Entities;

namespace UserService.Domain.Factories
{
    public static class UsuarioFactory
    {
        public static Usuario createFromCliente(ClienteDTO cliente)
        {
            return new Usuario(
                0, cliente.Nome, cliente.Email, cliente.Senha, cliente.IdProfile, cliente.Endereco,
                cliente.Cidade, cliente.NumeroResidencia, cliente.Telefone,
                cliente.Cep, null, cliente.Bairro, cliente.DeviceToken
                );
        }

        public static Usuario createFromMotorista(MotoristaDTO motorista)
        {

            return new Usuario(
                0, motorista.Nome, motorista.Email, motorista.Senha, motorista.IdProfile, motorista.Endereco,
                motorista.Cidade, motorista.NumeroResidencia, motorista.Telefone,
                motorista.Cep, motorista.Cnh, motorista.Bairro, motorista.DeviceToken
                );
        }

        public static List<String> extractDevicesToken(List<Usuario> usuarios)
        {
            List<String> tokens = new List<String>();
            usuarios.ForEach(u => tokens.Add(u.DeviceToken));
            return tokens;

        }
    }
}
