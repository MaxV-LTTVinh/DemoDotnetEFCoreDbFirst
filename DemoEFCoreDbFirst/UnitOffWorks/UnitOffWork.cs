using Common.FECore.Models;
using DemoEFCoreDbFirst.Repositories.BaseRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCoreDbFirst.UnitOffWorks
{
    public class UnitOffWork<TContext> : IUnitOffWork<TContext> where TContext: DbContext
    {
        private readonly TContext _dbContext;
        private readonly IServiceProvider _serviceProvider;
        private Dictionary<Type, object?>? _repositories;

        public UnitOffWork(TContext context, IServiceProvider serviceProvider)
        {
            _dbContext = context;
            _serviceProvider = serviceProvider;
        }

        //~UnitOffWork()
        //{
        //    Dispose(false);
        //}

        //public virtual void Dispose(bool disposing)
        //{
        //    if (_disposed)
        //    {
        //        return;
        //    }

        //    if (disposing)
        //    {
        //        _tx?.Dispose();
        //        _tx = null;
        //    }

        //    _disposed = true;
        //}
        //void IDisposable.Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task DoWorkWithTransaction(Action action)
        {
            await using var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                action.Invoke();
                await trans.CommitAsync();
            }
            catch
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task DoWorkWithTransaction(Task<Action> action)
        {
            await using var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                (await action).Invoke();
                await trans.CommitAsync();
            }
            catch
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<T> DoWorkWithTransaction<T>(Func<Task<T>> action)
        {
            await using var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var result = await action.Invoke();
                await trans.CommitAsync();
                return result;
            }
            catch
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public IQueryable<TResult> QueryAsync<TResult>(string query)
        {
            return _dbContext.Database.SqlQueryRaw<TResult>(query);
        }

        public IBaseRepository<TContext, TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {

            _repositories ??= new Dictionary<Type, object?>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
                _repositories[type] = _serviceProvider.GetService<IBaseRepository<TContext, TEntity, TKey>>();
            return _repositories[type] as IBaseRepository<TContext, TEntity, TKey> ?? throw new InvalidOperationException();
        }
    }
}
