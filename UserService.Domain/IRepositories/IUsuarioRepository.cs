using System.Threading.Tasks;
using UserService.Domain.Entities;
namespace UserService.Domain.IRepositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> Login(string email, string senha);
    }
}
