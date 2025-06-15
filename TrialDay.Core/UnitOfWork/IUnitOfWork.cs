using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialDay.Core.Abstraction;

namespace TrialDay.Core.UnitOfWork
{
    public interface IUnitOfWork :IAsyncDisposable
    {
        IRepo<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> CompleteAsync();

    }
}
