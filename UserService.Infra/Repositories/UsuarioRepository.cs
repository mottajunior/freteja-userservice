using UserService.Infra.Context;
using UserService.Domain.Entities;
using UserService.Domain.IRepositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace UserService.Infra.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext context) : base(context) { }

        public async Task<Usuario> Login(string email, string senha)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .Where(usuario => usuario.Email == email && usuario.Senha == senha)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Usuario>> GetAllMotoristas()
        {
            return await _context.Usuarios
            .AsNoTracking()
            .Where(usuario => usuario.IdProfile == 2)
            .ToListAsync();

        }
    }
}
