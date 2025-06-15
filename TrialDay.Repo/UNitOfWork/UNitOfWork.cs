using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialDay.Core.Abstraction;
using TrialDay.Core.UnitOfWork;
using TrialDay.Repo.Context;
using TrialDay.Repo.Repo;

namespace TrialDay.Repo.UNitOfWork
{
    public class UNitOfWork : IUnitOfWork , IAsyncDisposable , IDisposable
    {
        private readonly SchoolContext context;
        private Hashtable Reposatry;

        public UNitOfWork(SchoolContext context)
        {
            this.context = context;
            this.Reposatry = new Hashtable();
        }

        public async Task<int> CompleteAsync()
         => await context.SaveChangesAsync();

        public void Dispose()
        => context.Dispose();
        
        public async ValueTask DisposeAsync()
         => await context.DisposeAsync();

       
        public IRepo<TEntity> Repository<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name;

            if (!Reposatry.ContainsKey(key))
            {
                var repository = new Repo<TEntity>(context);

                Reposatry.Add(key, repository);
            }

            return Reposatry[key] as Repo<TEntity>;
        }
    }
}
