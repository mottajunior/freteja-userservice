using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;
using UserService.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserService.Infra.Context;
using System.Threading.Tasks;

namespace UserService.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        protected readonly DataContext _context;

        public RepositoryBase(DataContext context)
        {
            _context = context;
        }
        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().AsNoTracking().IgnoreQueryFilters().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking().IgnoreQueryFilters().ToList();
        }

        public async Task Save(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.Remove(entity);
        }

        public async Task<int> SaveReturningId(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }

}
