namespace UserService.Domain.Entities
{
    public class Veiculo : Entity
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public string Renavan { get; set; }
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        public float CargaMaximaKg { get; set; }

        public Veiculo(int id, string placa, string modelo, string cor, int ano, string renavan, int idUsuario, float cargaMaximaKg) : base(id)
        {
            this.Placa = placa;
            this.Modelo = modelo;
            this.Cor = cor;
            this.Ano = ano;
            this.Renavan = renavan;
            this.IdUsuario = idUsuario;
            this.CargaMaximaKg = cargaMaximaKg;

        }



    }



    // placa,modelo,cor,ano,renavan,id_user,carga_max_kg
}