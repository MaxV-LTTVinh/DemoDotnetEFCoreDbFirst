using Common.FECore.Models;
using DemoEFCoreDbFirst.Repositories.BaseRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCoreDbFirst.UnitOffWorks
{
    public interface IUnitOffWork<TContext> where TContext : DbContext//: IDisposable 
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
        Task DoWorkWithTransaction(Action action);
        Task DoWorkWithTransaction(Task<Action> action);
        Task<T> DoWorkWithTransaction<T>(Func<Task<T>> action);
        IQueryable<TResult> QueryAsync<TResult>(string query);
        IBaseRepository<TContext, TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}
