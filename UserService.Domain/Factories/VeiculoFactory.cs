using UserService.Domain.DTO;
using UserService.Domain.Entities;

namespace UserService.Domain.Factories
{
    public static class VeiculoFactory
    {
        public static Veiculo createFromVeiculo(VeiculoDTO veiculo)
        {
            return new Veiculo(
                0, veiculo.Placa, veiculo.Modelo, veiculo.Cor,
                veiculo.Ano, veiculo.Renavan, veiculo.IdUsuario, veiculo.CargaMaximaKg
            );
        }
    }

}