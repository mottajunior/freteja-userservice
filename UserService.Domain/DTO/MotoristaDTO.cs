using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Domain.DTO
{
    public class MotoristaDTO : ClienteDTO
    {
        public List<VeiculoDTO> Veiculos;
        public int Cnh;
    }
}
