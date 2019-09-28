using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Domain.Entities
{
    public class Perfil : Entity
    {
        public string Tipo { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public Perfil(int id, string tipo) : base(id)
        {
            this.Tipo = tipo;
        }
    }
}
