namespace Blog.DAL.Repository.Contracts;

public interface IUnitOfWork
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    int SaveChanges();
    void Dispose();
    Task<int> SaveChangesAsync();
}