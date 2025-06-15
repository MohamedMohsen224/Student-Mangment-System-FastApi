using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialDay.Core.Abstraction;
using TrialDay.Repo.Context;

namespace TrialDay.Repo.Repo
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly SchoolContext context;
        private readonly DbSet<T> _dbSet;


        public Repo(SchoolContext context)
        {
            this.context = context;
            _dbSet = context.Set<T>();

        }

        public async Task AddAsync(T entity)
        {
            _dbSet.Add(entity);
           await context.SaveChangesAsync();
        }

        public void DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            context.SaveChanges();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            context.SaveChanges();
        }
    }
}
