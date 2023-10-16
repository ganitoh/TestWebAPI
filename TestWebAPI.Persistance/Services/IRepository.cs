namespace TestWebAPI.Persistance.Services
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        TEntity? GetEntityAsync(string id);
        IEnumerable<TEntity> GetAllAsync();
        Task AddEntityAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteEntityASync(string id);
    }
}
