using UserService.Domain.Entities;
using UserService.Infra.Context;

namespace UserService.Infra.Repositories
{
    public class VeiculoRepository : RepositoryBase<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(DataContext context) : base(context) { }
    }
}
