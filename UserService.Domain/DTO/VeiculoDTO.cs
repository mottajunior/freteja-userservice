using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Domain.DTO
{
    public class VeiculoDTO
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public string Renavan { get; set; }
        public int IdUsuario { get; set; }
        public float CargaMaximaKg { get; set; }
    }
}
