using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.DTO;
using UserService.Domain.Entities;
using UserService.Domain.Factories;
using UserService.Domain.IRepositories;

namespace UserService.Service.Services
{
    public class UsuarioService
    {

        IUsuarioRepository _usuarioRepository;
        IVeiculoRepository _veiculoRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository, IVeiculoRepository veiculoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _veiculoRepository = veiculoRepository;

        }
        public async Task SalvarCliente(ClienteDTO cliente)
        {
            //possibles validations before save if startup make money
            await _usuarioRepository.Save(UsuarioFactory.createFromCliente(cliente));
        }

        public async Task SalvarMotorista(MotoristaDTO motorista)
        {
            //first() because this method is call when user signup with one veiculo.
            motorista.Veiculos.First().IdUsuario = await _usuarioRepository.SaveReturningId(UsuarioFactory.createFromMotorista(motorista));
            await _veiculoRepository.Save(VeiculoFactory.createFromVeiculo(motorista.Veiculos.First()));
        }
        public async Task<List<String>> obterTokenMotorista()
        {
            var usuarios = await _usuarioRepository.GetAllMotoristas();
            return UsuarioFactory.extractDevicesToken(usuarios);
        }

        public Usuario getUsuarioById(int id)
        {
            var usuario = _usuarioRepository.Get(id);
            return usuario;
        }
    }
}
