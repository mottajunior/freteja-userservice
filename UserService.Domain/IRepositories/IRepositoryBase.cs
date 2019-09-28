using UserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Domain.IRepositories
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task Save(TEntity entity);

        Task<int> SaveReturningId(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        void Delete(TEntity entity);

    }
}
